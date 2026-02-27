
namespace OOPSLearning
{
    internal class GymCharges
    {
        public static double CalculateGymMembership(bool treadmill, bool weightLifting, bool zumba)
        {
            double total = 1000; // Fixed monthly charge

            int serviceCount = 0;

            if (treadmill)
            {
                total += 300;
                serviceCount++;
            }

            if (weightLifting)
            {
                total += 500;
                serviceCount++;
            }

            if (zumba)
            {
                total += 250;
                serviceCount++;
            }

            // If no service selected
            if (serviceCount == 0)
            {
                total += 200;
            }

            // Add GST 5%
            total += total * 0.05;

            return total;
        }
        static void Main(string[] args)
        {
            double amount = CalculateGymMembership(true, false, true);
            Console.WriteLine($"Total Amount: {amount}");
        }
    }
}

