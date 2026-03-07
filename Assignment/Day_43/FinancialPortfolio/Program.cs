using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8
{
    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }
    public abstract class FinancialInstrument
    {
        private decimal quantity;
        private decimal purchasePrice;
        private decimal marketPrice;
        private string currency;

        public string InstrumentId { get; set; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }

        public decimal Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity cannot be negative");
                quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get => purchasePrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Price cannot be Negative");
                purchasePrice = value;
            }
        }

        public decimal MarketPrice
        {
            get => marketPrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Price cannot be Negative.");
                marketPrice = value;
            }
        }
        public string Currency
        {
            get => currency;
            set
            {
                if (value.Length != 3)
                    throw new InvalidFinancialDataException("Currency format must be 3 letter code");
                currency = value;
            }
        }

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} - {Name} : {CalculateCurrentValue():C}";
        }
    }

    public class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
        public string GetRiskCategory() => "High";
        public string GenerateReportLine()
        {
            return $"{InstrumentId} | Equity | {CalculateCurrentValue():C}";
        }
    }

    public class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
        public string GetRiskCategory() => "Low";

        public string GenerateReportLine()
        {
            return $"{InstrumentId} | Bond | {CalculateCurrentValue():C}";
        }
    }
    public class FixedDeposit : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

    public class MutualFund : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }


    public class Portfolio
    {
        private List<FinancialInstrument> instruments = new();
        private Dictionary<string, FinancialInstrument> lookup = new();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (lookup.ContainsKey(instrument.InstrumentId))
            {
                throw new Exception("Duplicate Instrument Id");
            }
            instruments.Add(instrument);
            lookup[instrument.InstrumentId] = instrument;
        }
        public void RemoveInstrument(string id)
        {
            if (lookup.ContainsKey(id))
            {
                instruments.Remove(lookup[id]);
                lookup.Remove(id);
            }
        }
        public FinancialInstrument GetInstrumentById(string id)
        {
            return lookup.ContainsKey(id) ? lookup[id] : null;
        }

        public decimal GetTotalPortfolioValue()
        {
            return instruments.Sum(i => i.CalculateCurrentValue());
        }

        public List<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            return instruments
                .Where(i => i is IRiskAssessable r && r.GetRiskCategory() == risk)
                .ToList();
        }
        public IEnumerable<FinancialInstrument> GetInstruments() => instruments;

    }
    class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }
        public decimal Units { get; set; }
        public DateTime Date { get; set; }

        public void Apply(Portfolio portfolio)
        {
            var instrument = portfolio.GetInstrumentById(InstrumentId);
            if (instrument == null) return;

            if (Type == "Buy")
            {
                instrument.Quantity += Units;
            }
            else if (Type == "Sell")
            {
                if (Units > instrument.Quantity)
                    throw new Exception("Cannot sell more than owned.");

                instrument.Quantity -= Units;
            }
        }
    }

    public class ReportGenerator
    {

        public static void GenerateConsoleReport(Portfolio portfolio)
        {
            Console.WriteLine("===== PORTFOLIO SUMMARY =====");

            var grouped = portfolio.GetInstruments()
                                   .GroupBy(i => i.GetType().Name);

            foreach (var group in grouped)
            {
                decimal totalInvestment = group.Sum(i => i.PurchasePrice * i.Quantity);
                decimal currentValue = group.Sum(i => i.CalculateCurrentValue());
                decimal profitLoss = currentValue - totalInvestment;

                Console.WriteLine($"\nInstrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {currentValue:C}");
                Console.WriteLine($"Profit/Loss: {profitLoss:C}");
            }

            // Overall value
            Console.WriteLine();
            Console.WriteLine($"\nOverall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            // Risk distribution
            Console.WriteLine("\nRisk Distribution:");

            var riskGroups = portfolio.GetInstruments()
                                      .OfType<IRiskAssessable>()
                                      .GroupBy(r => r.GetRiskCategory()).OrderBy(g => g.Key);

            foreach (var rg in riskGroups)
            {
                Console.WriteLine($"{rg.Key}: {rg.Count()}");
            }
        }
        public static void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $@"..\..\..\PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("===== PORTFOLIO REPORT =====");
                    writer.WriteLine($"Generated On: {DateTime.Now}");
                    writer.WriteLine(new string('-', 40));

                    // Instrument details
                    foreach (var inst in portfolio.GetInstruments()
                                                  .OrderByDescending(i => i.CalculateCurrentValue()))
                    {
                        if (inst is IReportable reportable)
                            writer.WriteLine(reportable.GenerateReportLine());
                        else
                            writer.WriteLine(inst.GetInstrumentSummary());
                    }

                    writer.WriteLine(new string('-', 40));

                    // Aggregated summary
                    decimal totalInvestment = portfolio.GetInstruments()
                        .Sum(i => i.PurchasePrice * i.Quantity);

                    decimal totalCurrent = portfolio.GetTotalPortfolioValue();

                    writer.WriteLine($"Total Investment: {totalInvestment.ToString("C", new CultureInfo("en-IN"))}");
                    writer.WriteLine($"Total Current Value: {totalCurrent.ToString("C", new CultureInfo("en-IN"))}");
                    writer.WriteLine($"Profit/Loss: {(totalCurrent - totalInvestment).ToString("C", new CultureInfo("en-IN"))}");
                    writer.WriteLine($"Report Timestamp: {DateTime.Now}");
                }

                Console.WriteLine($"Report generated: {Path.GetFileName(fileName)}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: File write permission denied.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File IO error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
    internal class FinancialPortFolio
    {
        static FinancialInstrument ParseFromCsv(string csv)
        {
            var parts = csv.Split(',');

            if (parts.Length != 7)
                throw new InvalidFinancialDataException("Invalid CSV format.");

            FinancialInstrument inst;

            string type = parts[1];

            if (type == "Equity")
                inst = new Equity();
            else if (type == "Bond")
                inst = new Bond();
            else if (type == "FixedDeposit")
                inst = new FixedDeposit();
            else if (type == "MutualFund")
                inst = new MutualFund();
            else
                throw new Exception("Unknown instrument type");

            inst.InstrumentId = parts[0];
            inst.Name = parts[2];
            inst.Currency = parts[3];
            inst.Quantity = decimal.Parse(parts[4]);
            inst.PurchasePrice = decimal.Parse(parts[5]);
            inst.MarketPrice = decimal.Parse(parts[6]);
            inst.PurchaseDate = DateTime.Now;

            return inst;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Portfolio portfolio = new Portfolio();
                FinancialInstrument eq = ParseFromCsv("EQ001,Equity,INFY,INR,100,1500,1650");

                FinancialInstrument bond = ParseFromCsv("BD001,Bond,SBI_BOND,INR,50,1000,1050");

                portfolio.AddInstrument(eq);
                portfolio.AddInstrument(bond);

                Transaction[] txArray =
                {
                new Transaction
                {
                    TransactionId = "T001",
                    InstrumentId = "EQ001",
                    Type = "Buy",
                    Units = 10,
                    Date = DateTime.Now
                },
                new Transaction
                {
                    TransactionId = "T002",
                    InstrumentId = "BD001",
                    Type = "Sell",
                    Units = 5,
                    Date = DateTime.Now
                }
                };
                List<Transaction> txList = txArray.ToList();
                foreach (var tx in txList)
                {
                    tx.Apply(portfolio);
                }

                ReportGenerator.GenerateConsoleReport(portfolio);
                ReportGenerator.GenerateFileReport(portfolio);
            }
            catch (InvalidFinancialDataException ex)
            {
                Console.WriteLine($"Financial data error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

        }
    }
}


