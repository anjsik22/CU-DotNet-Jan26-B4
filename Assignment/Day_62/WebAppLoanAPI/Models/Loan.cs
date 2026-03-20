namespace WebAppLoanAPI.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public string BorrowerName { get; set; }
        public decimal Amount { get; set; }
        public int LoanTermMonths { get; set; }
        public bool IsApproved { get; set; }
    }
}
