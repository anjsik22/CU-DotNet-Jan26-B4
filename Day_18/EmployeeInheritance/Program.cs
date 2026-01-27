namespace OOPSLearning
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }

        public Employee(int id, string name, decimal salary, int years)
        {
            EmployeeId=id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = years;
        }

        public decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12;
        }

        public string DisplayEmployeeDetails()
        {
            return $"Id - {EmployeeId}, Name - {EmployeeName}, Salary - {BasicSalary}," +
                $" Years - {ExperienceInYears}, Annual Salary - {CalculateAnnualSalary()}";
        }
    }

    class PermanentEmployee: Employee
    {
        public PermanentEmployee(int id, string name, decimal salary, int years) : base(id, name, salary, years)
        {     
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal annualSalary = BasicSalary * 12;
            decimal hra = BasicSalary * 0.20m;
            decimal allowance = BasicSalary * 0.10m;
            decimal bonus = 0;
            if(ExperienceInYears >5)
            {
                bonus = 50000;
            }
            return annualSalary+hra+allowance+bonus;

        }
    }

    class ContractEmployee: Employee
    {
        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int id, string name, decimal salary, int years ,int duration) : base(id, name, salary, years)
        {
            ContractDurationInMonths = duration;
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal annualSalary = BasicSalary * 12;
            decimal bonus = 0;
            if(ContractDurationInMonths > 12)
            {
                bonus = 30000;
            }
            return annualSalary + bonus;
        }    
    }

    class InternEmployee: Employee
    {
        public InternEmployee(int id, string name, decimal salary, int years) : base(id, name, salary, years)
        {
        }
        public new decimal CalculateAnnualSalary()
        {
            decimal stipend = BasicSalary;
            decimal annualSalary= BasicSalary * 12;
            return stipend + annualSalary;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Base Class Reference
            Employee emp1 = new Employee(1, "Rahul", 20000, 2);
            Employee emp2 = new PermanentEmployee(2, "Anjali", 30000, 6);
            Employee emp3 = new ContractEmployee(3, "Amit", 25000, 3, 14);
            Employee emp4 = new InternEmployee(4, "Neha", 15000, 3);

            Console.WriteLine("Base Class Reference");
            Console.WriteLine(emp1.CalculateAnnualSalary().ToString("N2")); // Base method
            Console.WriteLine(emp2.CalculateAnnualSalary().ToString("N2")); // Base method
            Console.WriteLine(emp3.CalculateAnnualSalary().ToString("N2")); // Base method
            Console.WriteLine(emp4.CalculateAnnualSalary().ToString("N2")); // Base method

            Console.WriteLine();

            // Derived class references
            PermanentEmployee p = new PermanentEmployee(5, "Kiran", 30000, 7);
            ContractEmployee c = new ContractEmployee(6, "Sonal", 28000, 4, 15);
            InternEmployee i = new InternEmployee(7, "Riya", 16000, 0);

            Console.WriteLine("Derived Class Reference");
            Console.WriteLine(p.CalculateAnnualSalary().ToString("N2")); // Derived method
            Console.WriteLine(c.CalculateAnnualSalary().ToString("N2")); // Derived method
            Console.WriteLine(i.CalculateAnnualSalary().ToString("N2")); // Derived method
        }
    }
}
