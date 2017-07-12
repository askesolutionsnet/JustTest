using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BanquetSystem.Data
{
    public class BanquetDbContext : DbContext
    {
        public BanquetDbContext()
            : base("BanquetSystemConnection")
        {
        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerEvent> CustomerEvent { get; set; }
        public DbSet<CustomerEventDetail> CustomerEventDetail { get; set; }
        public DbSet<CustomerImage> CustomerImage { get; set; }
        public DbSet<Theme> Theme { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<CustomerEventDetail>().Property(e => e.CostPerHead).HasPrecision(18, 2);
        }

    }
}
