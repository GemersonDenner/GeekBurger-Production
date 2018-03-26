using AutoMapper;
using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using GeekBurger.Production.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Helper
{
    public class MatchMessageFromRepository : IMappingAction<EntityEntry<ProductionArea>, ProductionAreaChangedMessage>
    {
        private IProductionAreaRepository _productionAreaRepository;

        public MatchMessageFromRepository(IProductionAreaRepository productionAreaRepository)
        {
            _productionAreaRepository = productionAreaRepository;
        }

        public void Process(EntityEntry<ProductionArea> source,  ProductionAreaChangedMessage destination)
        {
            destination.ProductionArea = new ProductionAreaTO { Id = source.Entity.Id   
                                                                , Name = source.Entity.Name
                                                                , Status = source.Entity.Status
                                                                , Restrictions = new List<string>()
                                                              };

            foreach(Restriction restriction in source.Entity.Restrictions)
            {
                destination.ProductionArea.Restrictions.Add(restriction.Name);
            }

            //destination.State = ProductionAreaChangedMessage.ProductionAreaState.Added;
        }
    }
}
