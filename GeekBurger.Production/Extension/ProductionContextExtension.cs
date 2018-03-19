using GeekBurger.Production.Model;
using GeekBurger.Production.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Extension
{
    public static class ProductionContextExtension
    {
        public static void Seed(this ProductionContext context)
        {
            context.ProductionAreas.RemoveRange(context.ProductionAreas);
            context.Restrictions.RemoveRange(context.Restrictions);

            context.SaveChanges();

            context.ProductionAreas.AddRange(
                                                new List<ProductionArea>()
                                                {
                                                    new ProductionArea
                                                    {   ProductionAreaId = new Guid("9524c16b-7642-42f1-bd0b-9fcc9c7335c0")
                                                        , Name = "Grill 1"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions = null
                                                    }
                                                    , new ProductionArea
                                                    {
                                                        ProductionAreaId = new Guid("1c8a9122-7d42-4884-90fd-cc90d830f723")
                                                        , Name = "Grill 2 - No Gluten&Wheat"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions
                                                            = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                    , Restriction 
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                            , Name = "gluten"
                                                                        }
                                                                }
                                                                , new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("e2fd7491-53f9-46b6-bc42-17a999735868")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("e2fd7491-53f9-46b6-bc42-17a999735868")
                                                                            , Name = "wheat"
                                                                        }
                                                                }
                                                            }
                                                    }
                                                    , new ProductionArea
                                                    {   ProductionAreaId = new Guid("7d0ab8cb-bda4-4008-a000-e6654ff3860e")
                                                        , Name = "Grill 3 - No Soy"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions
                                                           = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("fc13bae5-5dcc-4e72-9e4c-f63e9d1c3748")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("fc13bae5-5dcc-4e72-9e4c-f63e9d1c3748")
                                                                            , Name = "soy"
                                                                        }
                                                                }
                                                            }

                                                    }
                                                    , new ProductionArea
                                                    {
                                                        ProductionAreaId = new Guid("7c48711e-2eea-4707-bf2a-db1b39efe88a")
                                                        , Name = "Grill 4 - No Milk"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions
                                                            = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                            , Name = "milk"
                                                                        }
                                                                }
                                                            }
                                                    }
                                                    , new ProductionArea
                                                    {   ProductionAreaId = new Guid("81b5b371-1fe5-4be6-9eb6-e2a81aa62174")
                                                        , Name = "Grill 4 - No Soy, Milk & Gluten"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions
                                                            = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                            , Name = "milk"
                                                                        }
                                                                }
                                                                , new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("fc13bae5-5dcc-4e72-9e4c-f63e9d1c3748")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("fc13bae5-5dcc-4e72-9e4c-f63e9d1c3748")
                                                                            , Name = "soy"
                                                                        }
                                                                }
                                                                , new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                            , Name = "gluten"
                                                                        }
                                                                }
                                                                , new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("e2fd7491-53f9-46b6-bc42-17a999735868")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("e2fd7491-53f9-46b6-bc42-17a999735868")
                                                                            , Name = "wheat"
                                                                        }
                                                                }
                                                            }
                                                    }
                                                    , new ProductionArea
                                                    {
                                                        ProductionAreaId = new Guid("58431438-145b-43f5-8136-095cb1622d1c")
                                                        , Name = "Grill 5 - No Peanuts"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions
                                                            = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("208503f8-72c2-46df-98a4-934781a3c573")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("208503f8-72c2-46df-98a4-934781a3c573")
                                                                            , Name = "peanuts"
                                                                        }
                                                                }
                                                            }
                                                    }
                                                    , new ProductionArea
                                                    {
                                                        ProductionAreaId = new Guid("bb38b77a-6706-46b0-973c-8084bbb42ece")
                                                        , Name = "Grill 5 - No Sugar"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions
                                                            = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    RestrictionId = new Guid("7c5f0688-561c-4911-ada4-9f0a4b33def5")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            RestrictionId = new Guid("7c5f0688-561c-4911-ada4-9f0a4b33def5")
                                                                            , Name = "sugar"
                                                                        }
                                                                }
                                                            }
                                                    }
                                                }
                                            );

            context.SaveChanges();

        }
    }
}
