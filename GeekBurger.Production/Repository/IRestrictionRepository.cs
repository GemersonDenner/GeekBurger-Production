using GeekBurger.Production.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Repository
{
    public interface IRestrictionRepository
    {
        Restriction GetRestrictionByName(string restrictionName);
    }
}
