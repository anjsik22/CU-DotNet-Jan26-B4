
using System;

namespace SmartAccessControl
{
    class Program
    {
        static void Main()
        {
            // 1. Read entire input in one line
            string input = Console.ReadLine();

            // Split input
            string[] parts = input.Split('|');

            // Must have exactly 5 parts
            if (parts.Length != 5)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // ---------------- Validation ----------------

            // GateCode validation
            string gateCode = parts[0];
            if (gateCode.Length != 2 ||
                !char.IsLetter(gateCode[0]) ||
                !char.IsDigit(gateCode[1]))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // UserInitial validation
            if (parts[1].Length != 1)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            char userInitial = parts[1][0];
            if (!char.IsUpper(userInitial))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // AccessLevel validation
            if (!byte.TryParse(parts[2], out byte accessLevel) ||
                accessLevel < 1 || accessLevel > 7)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // IsActive validation
            if (!bool.TryParse(parts[3], out bool isActive))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // Attempts validation
            if (!byte.TryParse(parts[4], out byte attempts) ||
                attempts > 200)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            // ---------------- Business Logic ----------------
            string status;

            if (!isActive)
            {
                status = "ACCESS DENIED – INACTIVE USER";
            }
            else if (attempts > 100)
            {
                status = "ACCESS DENIED – TOO MANY ATTEMPTS";
            }
            else if (accessLevel >= 5)
            {
                status = "ACCESS GRANTED – HIGH SECURITY";
            }
            else
            {
                status = "ACCESS GRANTED – STANDARD";
            }

            // ---------------- Output Formatting ----------------
            Console.WriteLine($"{ "Gate",-10 }: {gateCode}");
            Console.WriteLine($"{ "User",-10 }: {userInitial}");
            Console.WriteLine($"{ "Level",-10 }: {accessLevel}");
            Console.WriteLine($"{ "Attempts",-10 }: {attempts}");
            Console.WriteLine($"{ "Status",-10 }: {status}");

        }
    }
}
