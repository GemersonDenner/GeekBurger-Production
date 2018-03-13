using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Model
{
    public class Restriction
    {
        [Key]
        public Guid RestrictionId { get; set; }
        public string Name { get; set; }

        public ICollection<ProductionAreaRestriction> ProductionAreasRestriction { get; set; }
    }
}
