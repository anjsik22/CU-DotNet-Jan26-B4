using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        [Required]
        [Display(Name ="Borrower Name")]
        public string BorrowerName { get; set; }
        public string LenderName { get; set; }
        [Range(1,50000)]
        public double Amount { get; set; }
        public bool IsSettled { get; set; }
    }
}
