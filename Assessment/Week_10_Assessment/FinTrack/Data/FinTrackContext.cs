using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinTrack.Models;

namespace FinTrack.Data
{
    public class FinTrackContext : DbContext
    {
        public FinTrackContext (DbContextOptions<FinTrackContext> options)
            : base(options)
        {
        }

        public DbSet<FinTrack.Models.Account> Account { get; set; } = default!;
        public DbSet<FinTrack.Models.Transaction> Transaction { get; set; } = default!;
    }
}
