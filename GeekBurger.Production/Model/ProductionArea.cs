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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<string> Restrictions { get; set; }

    }
}
