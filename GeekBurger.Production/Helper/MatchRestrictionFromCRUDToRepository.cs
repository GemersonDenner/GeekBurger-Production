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
    public class MatchRestrictionFromCRUDToRepository : IMappingAction<ProductionAreaCRUD, ProductionArea>
    {
        private IRestrictionRepository _restrictionRepository;

        public MatchRestrictionFromCRUDToRepository(IRestrictionRepository restrictionRepository)
        {
            _restrictionRepository = restrictionRepository;
        }

        public void Process(ProductionAreaCRUD source, ProductionArea destination)
        {
            if(source.Restrictions != null)
            {
                foreach (RestrictionCRUD restriction in source.Restrictions)
                {
                    var _restriction = _restrictionRepository.GetRestrictionByName(restriction.Name);


                    destination.ProductionAreaRestrictions = new List<ProductionAreaRestriction>();

                    if (_restriction != null)
                    { 
                        destination.ProductionAreaRestrictions.Add(new ProductionAreaRestriction
                                                                        {
                                                                            RestrictionId = _restriction.RestrictionId
                                                                            , Restriction = _restriction
                                                                            , ProductionArea = new ProductionArea
                                                                                                    {
                                                                                                        Name = source.Name
                                                                                                        , Type = (ProductionAreaType) source.Type
                                                                                                        , ProductionAreaId = Guid.NewGuid()
                                                                                                    }
                                                                        }
                                                                  );
                    }
                    else
                    {
                        var newRestrictionId = Guid.NewGuid();

                        destination.ProductionAreaRestrictions.Add(new ProductionAreaRestriction
                                                                        {
                                                                            RestrictionId = newRestrictionId
                                                                            , Restriction = new Restriction
                                                                                                {
                                                                                                    Name = restriction.Name
                                                                                                    , RestrictionId = newRestrictionId
                                                                                                }
                                                                            , ProductionArea = new ProductionArea
                                                                                                    {
                                                                                                        Name = source.Name
                                                                                                        , Type = (ProductionAreaType)source.Type
                                                                                                        , ProductionAreaId = Guid.NewGuid()
                                                                                                    }
                                                                        }
                                                                  );
                    }
                }
            }
        }
    }
}
