using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Production.Contract
{
    public class ProductionAreaTO
    {
        public Guid ProductionAreaId { get; set; }
        public string Name { get; set; }
        public ProductionAreaType Type { get; set; }

        public List<RestrictionTO> Restrictions { get; set; }

        public enum ProductionAreaType
        {
            Fritadeira = 0
            , Chapa = 1
            , Esteira = 2
        }
    }

}
