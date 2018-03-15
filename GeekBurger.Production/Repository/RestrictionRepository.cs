using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Production.Model;

namespace GeekBurger.Production.Repository
{
    public class RestrictionRepository : IRestrictionRepository
    {

        private ProductionContext _context;

        public RestrictionRepository(ProductionContext context)
        {
            _context = context;
        }


        public Restriction GetRestrictionByName(string restrictionName)
        {
            return _context.Restrictions?.FirstOrDefault(r => r.Name.Equals(restrictionName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
