using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Learning
{
    class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
    }
    internal class Portfolio
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string file = @"..\..\..\loan.csv";
            List<Loan> loans = new List<Loan>();

            //--------CREATE CSV FILE --------
            //writer.WriteLine("ClientName,Principal,InterestRate");
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                
                Console.WriteLine("Enter Client Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Principal Amount: ");
                double amount = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Interest Rate: ");
                double rate = double.Parse(Console.ReadLine());

                loans.Add(new Loan
                {
                    ClientName = name,
                    Principal = amount,
                    InterestRate = rate
                });

                foreach (Loan loan in loans)
                {
                    writer.WriteLine($"{loan.ClientName},{loan.Principal},{loan.InterestRate}");
                }
            }

            using (StreamReader sr=new StreamReader(file))
            {
                sr.ReadLine();
                string line;
                Console.WriteLine(
                    $"{"CLIENT",-10} | "+
                    $"{"PRINCIPAL",-13} | "+
                    $"{"INTEREST",-10} | "+
                    "RISK LEVEL"

                );
                Console.WriteLine("----------------------------------------------------");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts=line.Split(',');

                    if (parts.Length == 3 && double.TryParse(parts[1], out double principal) &&
                         double.TryParse(parts[2], out double Rate))
                    {
                        double interestRate = (principal * Rate) / 100;
                        string risk;
                        if ( Rate> 10)
                        {
                            risk = "HIGH";
                        }
                        else if(Rate>5 && Rate<10)
                        {
                            risk = "MEDIUM";
                        }
                        else
                        {
                            risk = "LOW";
                        }
                        
                        Console.WriteLine(
                        $"{parts[0],-10} | " +
                        $"{principal,-13:C} | " +
                        $"{interestRate,-10:C} | " +
                        $"{risk}"
                        );
                    }
                }

            }
        }
    }
}

