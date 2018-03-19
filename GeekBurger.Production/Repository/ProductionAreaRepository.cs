using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GeekBurger.Production.Model;
using GeekBurger.Production.Service;

namespace GeekBurger.Production.Repository
{
    public class ProductionAreaRepository : IProductionAreaRepository
    {

        private ProductionContext _context;
        private IProductionAreaChangedService _productionAreaChangedService;

        public ProductionAreaRepository(ProductionContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductionArea> GetAvailableProductionAreas()
        {
            return _context.ProductionAreas?.Include(par => par.ProductionAreaRestrictions)
                                                .ThenInclude(r => r.Restriction)
                                                .ToList();
        }

        public IEnumerable<ProductionArea> GetProductionAreasByRestrictionName(string restrictionName)
        {
            List<ProductionArea> retorno = new List<ProductionArea>();

            List<ProductionArea> pa = _context.ProductionAreas?.Include(par => par.ProductionAreaRestrictions)
                                        .ThenInclude(r => r.Restriction).ToList();

            foreach(ProductionArea p in pa)
            {
                foreach(ProductionAreaRestriction par in p.ProductionAreaRestrictions)
                {
                    if(par.Restriction.Name == restrictionName)
                    {
                        retorno.Add(p);
                        break;
                    }
                }
            }

            return retorno;
        }


        public ProductionArea GetProductionAreaById(Guid productionAreaId)
        {
            return _context.ProductionAreas?
                                    .Include(productionArea => productionArea.ProductionAreaRestrictions)
                                    .ThenInclude(r => r.Restriction)
                                    .FirstOrDefault(productionArea => productionArea.ProductionAreaId == productionAreaId);
        }

        public bool CreateProductionArea(ProductionArea productionArea)
        {
            productionArea.ProductionAreaId = new Guid();
            _context.ProductionAreas.Add(productionArea);

            return true;
        }

        public bool UpdateProductionArea(Guid productionAreaId, ProductionArea updatedProductionArea)
        {
            var productionAreaToUpdate = _context.ProductionAreas?.FirstOrDefault(pa => pa.ProductionAreaId == productionAreaId);

            if (EqualityComparer<ProductionArea>.Default.Equals(productionAreaToUpdate, default(ProductionArea)))
                return false;


            productionAreaToUpdate.Name = updatedProductionArea.Name;
            productionAreaToUpdate.Type = updatedProductionArea.Type;
            productionAreaToUpdate.ProductionAreaRestrictions = updatedProductionArea.ProductionAreaRestrictions;

            _context.ProductionAreas.Update(productionAreaToUpdate);
            
            return true;
        }

        public bool RemoveProductionArea(Guid productionAreaId)
        {
            var productionAreaToDelete = _context.ProductionAreas?.FirstOrDefault(pa => pa.ProductionAreaId == productionAreaId);

            if (EqualityComparer<ProductionArea>.Default.Equals(productionAreaToDelete, default(ProductionArea)))
                return false;

            _context.ProductionAreas?.Remove(productionAreaToDelete);

            return true;
        }



        public void Save()
        {
            _productionAreaChangedService
                .AddToMessageList(_context.ChangeTracker.Entries<ProductionArea>());

            _context.SaveChanges();


            _productionAreaChangedService.SendMessagesAsync();
        }
    }
}
