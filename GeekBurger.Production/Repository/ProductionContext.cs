using GeekBurger.Production.Model;
using GeekBurger.Production.Repository.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Repository
{
    public class ProductionContext : DbContext
    {
        public ProductionContext(DbContextOptions<ProductionContext> options) : base(options)
        {
        }


        public DbSet<ProductionArea> ProductionAreas { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductionAreaConfiguration());
            modelBuilder.ApplyConfiguration(new RestrictionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionAreaRestrictionConfiguration());
        }
    }
}
