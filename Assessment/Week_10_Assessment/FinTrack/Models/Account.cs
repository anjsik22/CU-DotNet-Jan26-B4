using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FinTrack.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string AccountNo { get; set; }

        public string AccountHolder { get; set; }

        public double Balance { get; set; }
        [ValidateNever]
        public List<Transaction> Transactions { get; set; }
    }
}
