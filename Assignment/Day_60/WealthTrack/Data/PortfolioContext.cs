using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WealthTrack.Models;

namespace WealthTrack.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext (DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<WealthTrack.Models.Investment> Investment { get; set; } = default!;
    }
}
