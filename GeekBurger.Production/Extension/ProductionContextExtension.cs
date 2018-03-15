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
                                                        , Name = "Fritadeira 1"
                                                        , Type = ProductionAreaType.Fritadeira
                                                        , ProductionAreaRestrictions = null
                                                    }
                                                    , new ProductionArea
                                                    {
                                                        ProductionAreaId = new Guid("1c8a9122-7d42-4884-90fd-cc90d830f723")
                                                        , Name = "Fritadeira sem gluten"
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
                                                                            , Name = "Gluten"
                                                                        }
                                                                }
                                                            }
                                                    }

                                                    , new ProductionArea
                                                    {   ProductionAreaId = new Guid("7d0ab8cb-bda4-4008-a000-e6654ff3860e")
                                                        , Name = "Chapa 1"
                                                        , Type = ProductionAreaType.Chapa
                                                        , ProductionAreaRestrictions = null
                                                    }
                                                    , new ProductionArea
                                                    {   ProductionAreaId = new Guid("7c48711e-2eea-4707-bf2a-db1b39efe88a")
                                                        , Name = "Chapa 2"
                                                        , Type = ProductionAreaType.Chapa
                                                        , ProductionAreaRestrictions = null
                                                    }
                                                    , new ProductionArea
                                                    {
                                                        ProductionAreaId = new Guid("81b5b371-1fe5-4be6-9eb6-e2a81aa62174")
                                                        , Name = "Chapa sem gluten"
                                                        , Type = ProductionAreaType.Chapa
                                                        , ProductionAreaRestrictions
                                                            = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    //RestrictionId = new Guid("6f518619-16d9-4456-9304-9c5d7defeed5")
                                                                    RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            //RestrictionId = new Guid("6f518619-16d9-4456-9304-9c5d7defeed5")
                                                                            RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                            , Name = "Gluten"
                                                                        }
                                                                }
                                                            }
                                                    }

                                                    , new ProductionArea
                                                    {   ProductionAreaId = new Guid("58431438-145b-43f5-8136-095cb1622d1c")
                                                        , Name = "Esteira 1"
                                                        , Type = ProductionAreaType.Esteira
                                                        , ProductionAreaRestrictions = null
                                                    }
                                                    , new ProductionArea
                                                    {
                                                        ProductionAreaId = new Guid("bb38b77a-6706-46b0-973c-8084bbb42ece")
                                                        , Name = "Esteira sem gluten"
                                                        , Type = ProductionAreaType.Esteira
                                                        , ProductionAreaRestrictions
                                                            = new List<ProductionAreaRestriction>
                                                            {
                                                                new ProductionAreaRestriction
                                                                {
                                                                    //RestrictionId = new Guid("994a26bd-1ad9-4660-b0f7-76ef2026f5a6")
                                                                    RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                    , Restriction
                                                                        = new Restriction
                                                                        {
                                                                            //RestrictionId = new Guid("994a26bd-1ad9-4660-b0f7-76ef2026f5a6")
                                                                            RestrictionId = new Guid("1235c114-777c-494d-bba9-3f7a9ac86b74")
                                                                            , Name = "Gluten"
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
