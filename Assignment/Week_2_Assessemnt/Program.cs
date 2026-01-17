namespace week2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] policyHoldernames = new string[5];
            decimal[] annualPremiums = new decimal[5];


            //--------Input----------
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    Console.Write($"Enter name of PolicyHolder {i + 1}: ");
                    string name = Console.ReadLine();

                    if (!string.IsNullOrEmpty(name))
                    {
                        policyHoldernames[i] = name;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Name is incorrect. Re-enter please");
                    }

                }
                while (true)
                {
                    Console.Write($"Enter Annual Premium amount for {policyHoldernames[i]}:");
                    bool isValid = decimal.TryParse(Console.ReadLine(), out decimal annualPremiumAmount);

                    if (isValid && annualPremiumAmount > 0)
                    {
                        annualPremiums[i] = annualPremiumAmount;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid amount. Please re-enter again.");
                    }

                }
            }

            //-------Processing(Value Types)--------

            decimal totalPremium = 0;
            decimal highestPremium = annualPremiums[0];
            decimal lowestPremium = annualPremiums[0];

            for (int i = 0; i < 5; i++)
            {
                totalPremium += annualPremiums[i];

                if (annualPremiums[i] > highestPremium)
                {
                    highestPremium = annualPremiums[i];
                }

                if (annualPremiums[i] < lowestPremium)
                {
                    lowestPremium = annualPremiums[i];
                }
            }

            decimal averagePremium = totalPremium / 5;

            //------------String Operations----------
            for (int i = 0; i < 5; i++)
            {
                policyHoldernames[i] = policyHoldernames[i].ToUpper();
            }
            // ------- OUTPUT ----------
            Console.WriteLine("\nInsurance Premium Summary");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("{0,-15} {1,15} {2,15}", "Name", "Premium", "Category");
            Console.WriteLine("-------------------------------------------------------------");

            for (int i = 0; i < 5; i++)
            {
                string category;

                if (annualPremiums[i] < 10000)
                    category = "LOW";
                else if (annualPremiums[i] <= 25000)
                    category = "MEDIUM";
                else
                    category = "HIGH";

                Console.WriteLine("{0,-15} {1,15:F2} {2,15}", policyHoldernames[i], annualPremiums[i], category);

            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine($"Total Premium   : {totalPremium:F2}");
            Console.WriteLine($"Average Premium : {averagePremium:F2}");
            Console.WriteLine($"Highest Premium : {highestPremium:F2}");
            Console.WriteLine($"Lowest Premium  : {lowestPremium:F2}");
        }


    }
}

