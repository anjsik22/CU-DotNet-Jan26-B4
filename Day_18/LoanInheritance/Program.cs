namespace OOPSLearning
{
    class Loan
    {
        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName= string.Empty;
            PrincipalAmount = 0;
            TenureInYears = 0;
        }

        public Loan(string loanAmount,string name, decimal principalAmount, int years)
        {
            LoanNumber = loanAmount;
            CustomerName = name;
            PrincipalAmount = principalAmount;
            TenureInYears = years;
        }

        public decimal CalculateEMI()
        {
            return (PrincipalAmount * TenureInYears* 10m)/100;
        }

        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }
    }

    class HomeLoan : Loan {
        public HomeLoan(string loanAmount, string name, decimal principalAmount, int years) : base(loanAmount, name, principalAmount, years)
        {
        }
        public new decimal CalculateEMI()
        {
            decimal processingFee = PrincipalAmount * 0.01m;
            decimal totalPrincipal = PrincipalAmount + processingFee;

            return (totalPrincipal * TenureInYears * 8m) / 100;

        }

    }

    class CarLoan: Loan
    {
        public CarLoan(string loanAmount, string name, decimal principalAmount, int years): base(loanAmount, name, principalAmount, years)
        {

        }
        public new decimal CalculateEMI()
        {
            return ((PrincipalAmount+15000) * TenureInYears * 9m) / 100;
        }
    }
    internal class Demo5LoanInheritance
    {
        static void Main(string[] args)
        {
            Loan[] loan = new Loan[4]
            {
                new HomeLoan("1011A","Anand",100000,4),
                new HomeLoan("1011B","Aastha",120000,3),
                new CarLoan("2011A","Anjali",300000,2),
                new CarLoan("2011B","Dhrupad",150000,4)
            };

            for (int i = 0; i < loan.Length; i++)
            {
                Console.WriteLine(loan[i].CalculateEMI().ToString("N2"));
            }

        }
    }
}
