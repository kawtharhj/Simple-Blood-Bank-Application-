using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodBank.Models;

namespace BloodBank.Data
{
    public class BloodBankContext : DbContext
    {
        public BloodBankContext (DbContextOptions<BloodBankContext> options)
            : base(options)
        {
        }

        public DbSet<BloodBank.Models.Donor> Donor { get; set; } = default!;
        public DbSet<Client> Client { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().ToTable("Clients");
        }
    }
}
