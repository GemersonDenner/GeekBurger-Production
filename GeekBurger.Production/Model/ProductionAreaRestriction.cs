using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Model
{
    public class ProductionAreaRestriction
    {
        public Guid ProductionAreaId { get; set; }
        public ProductionArea ProductionArea { get; set; }

        public Guid RestrictionId { get; set; }
        public Restriction Restriction { get; set; }
    }
}
