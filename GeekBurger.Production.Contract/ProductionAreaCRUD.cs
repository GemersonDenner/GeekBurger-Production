using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Production.Contract
{
    public class ProductionAreaCRUD
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<string> Restrictions { get; set; }

    }

}