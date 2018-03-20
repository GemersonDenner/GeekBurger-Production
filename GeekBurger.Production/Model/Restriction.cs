using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Production.Model
{
    public class Restriction
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
