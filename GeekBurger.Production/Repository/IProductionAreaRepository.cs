﻿using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Production.Repository
{
    /// <summary>
    /// Interface utilizada para o repositório de área de produção
    /// </summary>
    public interface IProductionAreaRepository
    {
        IEnumerable<ProductionArea> GetAvailableProductionAreas();
        IEnumerable<ProductionArea> GetProductionAreasByRestrictionName(string restrictionName);

        ProductionArea GetProductionAreaById(Guid productionAreaId);
        bool CreateProductionArea(ProductionArea productionArea);
        bool UpdateProductionArea(Guid productionAreaId, ProductionArea productionArea);
        bool RemoveProductionArea(Guid productionAreaId);

        void Save();
    }
}
