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
    public class MatchRestrictionFromRepositoryToTO : IMappingAction<ProductionArea, ProductionAreaTO>
    {
        private IRestrictionRepository _restrictionRepository;

        public MatchRestrictionFromRepositoryToTO(IRestrictionRepository restrictionRepository)
        {
            _restrictionRepository = restrictionRepository;
        }

        public void Process(ProductionArea source, ProductionAreaTO destination)
        {
            destination.Restrictions = new List<RestrictionTO>();

            foreach (ProductionAreaRestriction par in source.ProductionAreaRestrictions)
            {
                destination.Restrictions.Add(
                                                new RestrictionTO {
                                                                    Name = par.Restriction.Name
                                                                    , RestrictionId = par.RestrictionId
                                                                  }
                                            );
            }
        }
    }
}
