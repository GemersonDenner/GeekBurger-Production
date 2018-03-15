using GeekBurger.Production.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Repository.EntityConfig
{
    public class ProductionAreaConfiguration : IEntityTypeConfiguration<ProductionArea>
    {
        public void Configure(EntityTypeBuilder<ProductionArea> builder)
        {
            builder.ToTable("TBProductionArea");
        }
    }
}
