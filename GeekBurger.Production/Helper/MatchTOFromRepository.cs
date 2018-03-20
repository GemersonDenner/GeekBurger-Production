using AutoMapper;
using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using GeekBurger.Production.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Helper
{
    public class MatchTOFromRepository : IMappingAction<ProductionArea, ProductionAreaTO>
    {
        private IProductionAreaRepository _productionAreaRepository;
        public MatchTOFromRepository(IProductionAreaRepository productionAreaRepository)
        {
            _productionAreaRepository = productionAreaRepository;
        }

        public void Process(ProductionArea source, ProductionAreaTO destination)
        {
            foreach(Restriction restriction in source.Restrictions)
            {
                destination.Restrictions.Add(restriction.Name);
            }
        }
    }
}
