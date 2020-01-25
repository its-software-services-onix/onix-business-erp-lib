using Microsoft.EntityFrameworkCore;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Databases;

namespace Its.Onix.Erp.Databases
{
	public class OnixErpDbContext : BaseDbContext
	{
        public OnixErpDbContext(DbCredential credential) : base(credential)
        {
        }

        private void SetConstraintMaster(ModelBuilder builder)
        {
            builder.Entity<Master>()
                .HasIndex(u => u.Code)
                .IsUnique();
        }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetConstraintMaster(modelBuilder);
        }

        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
