using GeekBurger.Production.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Repository.EntityConfig
{
    public class ProductionAreaRestrictionConfiguration : IEntityTypeConfiguration<ProductionAreaRestriction>
    {
        public void Configure(EntityTypeBuilder<ProductionAreaRestriction> builder)
        {
            builder.ToTable("TBProductionAreaRestriction");

            builder.HasKey(par => new { par.ProductionAreaId, par.RestrictionId});


            builder.HasOne(par => par.ProductionArea)
                    .WithMany(pa => pa.ProductionAreaRestrictions)
                    .HasForeignKey(par => par.ProductionAreaId);

            builder.HasOne(par => par.Restriction)
                    .WithMany(r => r.ProductionAreasRestriction)
                    .HasForeignKey(par => par.RestrictionId);
        }
    }
}
