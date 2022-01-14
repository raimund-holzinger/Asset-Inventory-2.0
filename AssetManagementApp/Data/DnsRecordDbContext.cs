using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementApp.Models
{
    public class DnsRecordDbContext : DbContext
    {
        public DnsRecordDbContext (DbContextOptions<DnsRecordDbContext> options)
            : base(options)
        {
        }

        public DbSet<AssetManagementApp.Models.DnsRecord> DnsRecord { get; set; }
    }
}
