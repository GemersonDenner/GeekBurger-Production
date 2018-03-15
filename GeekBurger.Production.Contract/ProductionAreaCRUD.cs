using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Production.Contract
{
    public class ProductionAreaCRUD
    {
        public string Name { get; set; }
        public ProductionAreaType Type { get; set; }

        public List<RestrictionCRUD> Restrictions { get; set; }

        public enum ProductionAreaType
        {
            Fritadeira = 0
            , Chapa = 1
            , Esteira = 2
        }
    }

}