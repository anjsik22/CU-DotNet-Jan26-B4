using System;

namespace ValueTypeCaseStudy
{
    class Program
    {
        static void Main()
        {
            // =====================================
        // Exercise 1: Student Attendance
        // =====================================
        int totalClasses = 100;
        int attendedClasses = 83;

        double attendancePercentage =
            (double)attendedClasses / totalClasses * 100;

        int attendanceTruncated = (int)attendancePercentage;
        int attendanceRounded = (int)Math.Round(attendancePercentage);

        Console.WriteLine("Exercise 1");
        Console.WriteLine(attendancePercentage);
        Console.WriteLine(attendanceTruncated);
        Console.WriteLine(attendanceRounded);
        Console.WriteLine();


        // =====================================
        // Exercise 2: Online Exam Results
        // =====================================
        int m1 = 78;
        int m2 = 85;
        int m3 = 92;

        double averageMarks = (m1 + m2 + m3) / 3.0;
        double averageRoundedTwoDecimals =
            Math.Round(averageMarks, 2);

        int scholarshipEligibleAverage =
            (int)Math.Round(averageMarks);

        Console.WriteLine("Exercise 2: Exam Results");
        Console.WriteLine(averageRoundedTwoDecimals);
        Console.WriteLine(scholarshipEligibleAverage);
        Console.WriteLine();


        // =====================================
        // Exercise 3: Library Fine
        // =====================================
        decimal finePerDay = 10.5m;
        int overdueDays = 3;

        decimal totalFine = finePerDay * overdueDays;
        double fineForAnalytics = (double)totalFine;

        Console.WriteLine("Exercise 3");
        Console.WriteLine(totalFine);
        Console.WriteLine(fineForAnalytics);
        Console.WriteLine();


        // =====================================
        // Exercise 4: Banking Interest
        // =====================================
          decimal accountBalance = 20000m;
        float annualInterestRate = 5f;

        decimal monthlyInterest =
            accountBalance * (decimal)annualInterestRate / 100;

        accountBalance =
            accountBalance + monthlyInterest;

        Console.WriteLine("Exercise 4: Bank Interest");
        Console.WriteLine(accountBalance);
        Console.WriteLine();


        // =====================================
        // Exercise 5: E-Commerce Pricing
        // =====================================
        double cartTotal = 999.99;
        decimal taxRate = 0.18m;
        decimal discount = 100m;

        decimal finalAmount = (decimal)cartTotal;
        finalAmount = finalAmount + (finalAmount * taxRate);
        finalAmount = finalAmount - discount;

        Console.WriteLine("Exercise 5");
        Console.WriteLine(finalAmount);
        Console.WriteLine();


        // =====================================
        // Exercise 6: Weather Monitoring
        // =====================================
        short sensorValue = 300;

        double temperatureCelsius = sensorValue - 273;
        int displayTemperature = (int)Math.Round(temperatureCelsius);

        Console.WriteLine("Exercise 6");
        Console.WriteLine(displayTemperature);
        Console.WriteLine();


        // =====================================
        // Exercise 7: University Grading
        // =====================================
        double finalScore = 82.5;
        byte grade;

        if (finalScore >= 80)
            grade = 1;
        else
            grade = 2;

        Console.WriteLine("Exercise 7");
        Console.WriteLine(grade);
        Console.WriteLine();


        // =====================================
        // Exercise 8: Mobile Data Usage
        // =====================================
        long dataUsageInBytes = 5368709120;

// convert bytes to MB
double dataUsageInMB =
    dataUsageInBytes / (1024.0 * 1024);

// convert bytes to GB
double dataUsageInGB =
    dataUsageInBytes / (1024.0 * 1024 * 1024);

// round monthly usage to nearest integer
int roundedMonthlyUsage =
    (int)Math.Round(dataUsageInGB);

Console.WriteLine("Exercise 8: Mobile Data Usage");
Console.WriteLine(dataUsageInMB);
Console.WriteLine(dataUsageInGB);
Console.WriteLine(roundedMonthlyUsage);
Console.WriteLine();


        // =====================================
        // Exercise 9: Warehouse Inventory
        // =====================================
        int itemCount = 450;
        ushort maxCapacity = 500;

        bool withinLimit = itemCount <= maxCapacity;

        Console.WriteLine("Exercise 9");
        Console.WriteLine(withinLimit);
        Console.WriteLine();


        // =====================================
        // Exercise 10: Payroll Salary
        // =====================================
        int basicSalary = 25000;
        double allowance = 5000.75;
        double deduction = 1200.50;

        decimal netSalary = basicSalary;
        netSalary = netSalary + (decimal)allowance;
        netSalary = netSalary - (decimal)deduction;

        Console.WriteLine("Exercise 10");
        Console.WriteLine(netSalary);
        }
    }
}
