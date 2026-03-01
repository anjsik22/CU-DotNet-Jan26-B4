namespace ClassLibrary1
{
    public class Class1
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                {
                    return 0m;
                }
                if (AttendancePercentage < 0 || AttendancePercentage > 100)
                    throw new InvalidOperationException("Invalid Attendance Percentage");

                //base bonus percentage
                decimal bonuspercent = 0m;
                if (PerformanceRating == 5) bonuspercent = 0.25m;
                else if (PerformanceRating == 4) bonuspercent = 0.18m;
                else if (PerformanceRating == 3) bonuspercent = 0.12m;
                else if (PerformanceRating == 2) bonuspercent = 0.05m;
                else if (PerformanceRating == 1) bonuspercent = 0m;
                else
                    throw new InvalidOperationException("Invalid rating");

                decimal bonus = BaseSalary * bonuspercent;

                //Experience bonus
                decimal expPercent = 0m;
                if (YearsOfExperience > 10) expPercent = 0.05m;
                else if (YearsOfExperience > 5) expPercent = 0.03m;

                bonus += BaseSalary * expPercent;

                //Attendance Penalty
                if (AttendancePercentage < 85)
                    bonus *= 0.80m;

                //Department Multiplier
                bonus *= DepartmentMultiplier;

                //Maximum Cap
                decimal maxBonus = BaseSalary * 0.40m;
                if (bonus > maxBonus)
                    bonus = maxBonus;

                //Tax deduction
                decimal taxRate = 0m;
                if (bonus <= 150000m) taxRate = 0.10m;
                else if (bonus > 150000 && bonus <= 300000) taxRate = 0.20m;
                else
                    taxRate = 0.30m;

                decimal finalBonus = bonus * (1 - taxRate);
                 return Math.Round(finalBonus, 2);

            }
            
        }
    }
}

