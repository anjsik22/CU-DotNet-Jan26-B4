using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppLoanAPI.Models;

namespace WebAppLoanAPI.Data
{
    public class WebAppLoanAPIContext : DbContext
    {
        public WebAppLoanAPIContext (DbContextOptions<WebAppLoanAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loan { get; set; } = default!;
    }
}
