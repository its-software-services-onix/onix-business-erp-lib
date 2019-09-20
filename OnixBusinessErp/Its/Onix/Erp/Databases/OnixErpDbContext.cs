using System;
using Microsoft.EntityFrameworkCore;

using Its.Onix.Erp.Models.Generals;

namespace Its.Onix.Erp.Databases
{
	public class OnixErpDbContext : BaseDbContext
	{
        public OnixErpDbContext(DbCredential credential) : base(credential)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Configure(optionsBuilder);
        }

        public DbSet<MasterRef> MasterRefs { get; set; }
    }
}
