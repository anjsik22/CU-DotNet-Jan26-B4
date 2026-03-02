using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        protected Subscriber(Guid id, string name, DateTime joinDate)
        {
            ID = id;
            Name = name;
            JoinDate = joinDate;
        }

        // Abstract method
        public abstract decimal CalculateMonthlyBill();

        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
                return this.ID == other.ID;
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        // Default sorting
        public int CompareTo(Subscriber other)
        {
            int dateCompare = this.JoinDate.CompareTo(other.JoinDate);
            if (dateCompare != 0)
                return dateCompare;

            return string.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public BusinessSubscriber(Guid id, string name, DateTime joinDate,
                                  decimal fixedRate, decimal taxRate)
            : base(id, name, joinDate)
        {
            FixedRate = fixedRate;
            TaxRate = taxRate;
        }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }
    public class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public ConsumerSubscriber(Guid id, string name, DateTime joinDate,
                                  decimal dataUsageGB, decimal pricePerGB)
            : base(id, name, joinDate)
        {
            DataUsageGB = dataUsageGB;
            PricePerGB = pricePerGB;
        }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }
    public static class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("===== Revenue Report =====");
            sb.AppendLine(
                $"{"Name",-15} {"Type",-12} {"Monthly Bill",15}");
            sb.AppendLine(new string('-', 45));

            foreach (var sub in subscribers)
            {
                string type = sub is BusinessSubscriber ? "Business" : "Consumer";
                decimal bill = sub.CalculateMonthlyBill();

                sb.AppendLine(
                    $"{sub.Name,-15} {type,-12} {bill,15:C2}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
    internal class SaasArchitect
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Dictionary<string, Subscriber> subscribersDict = new Dictionary<string, Subscriber>();

            // Adding subscribers
            subscribersDict["a@saas.com"] = new BusinessSubscriber(Guid.NewGuid(), "AlphaCorp",
                new DateTime(2024, 1, 10), 1000m, 0.18m);

            subscribersDict["b@saas.com"] = new ConsumerSubscriber(Guid.NewGuid(), "Rohit",
                new DateTime(2024, 3, 5), 50m, 2m);

            subscribersDict["c@saas.com"] = new BusinessSubscriber(Guid.NewGuid(), "BetaLtd",
                new DateTime(2023, 12, 1), 2000m, 0.15m);

            subscribersDict["d@saas.com"] = new ConsumerSubscriber(Guid.NewGuid(), "Anjali",
                new DateTime(2024, 2, 20), 120m, 1.5m);

            subscribersDict["e@saas.com"] = new ConsumerSubscriber(Guid.NewGuid(), "Vikas",
                new DateTime(2024, 1, 25), 80m, 2.2m);

            var sortedSubscribers = subscribersDict
                .OrderByDescending(kvp => kvp.Value.CalculateMonthlyBill())
                .Select(kvp => kvp.Value)
                .ToList();

            // Print report
            ReportGenerator.PrintRevenueReport(sortedSubscribers);
        }
    }
}

