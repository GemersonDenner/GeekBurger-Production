using System;
using System.Collections.Generic;
using System.Text;

namespace GeekBurger.Production.Contract
{
    public class ProductionAreaChangedMessage
    {
        public ProductionAreaTO ProductionArea { get; set; }
        public ProductionAreaStatus Status { get; set; }
    }

    public enum ProductionAreaStatus
    {
        Available = 0
        , Unavailable = 1
    }
}
