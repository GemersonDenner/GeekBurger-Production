using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Model
{
    public class ProductionArea
    {
        [Key]
        public Guid ProductionAreaId { get; set; }
        public string Name { get; set; }
        public ProductionAreaType Type { get; set; }

        //public ICollection<Restriction> Restrictions { get; set; }
        public ICollection<ProductionAreaRestriction> ProductionAreaRestrictions { get; set; }
    }

    public enum ProductionAreaType
    {
        Fritadeira = 0
        , Chapa = 1
        , Esteira = 2
    }
}
