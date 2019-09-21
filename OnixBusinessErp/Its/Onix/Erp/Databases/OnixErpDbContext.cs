using System;
using Microsoft.EntityFrameworkCore;

using Its.Onix.Erp.Models.Generals;
using Its.Onix.Core.Databases;

namespace Its.Onix.Erp.Databases
{
	public class OnixErpDbContext : BaseDbContext
	{
        public OnixErpDbContext(DbCredential credential) : base(credential)
        {
        }

        public DbSet<Master> MasterRefs { get; set; }
    }
}
