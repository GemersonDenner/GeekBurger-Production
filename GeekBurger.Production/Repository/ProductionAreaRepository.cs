using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GeekBurger.Production.Model;


namespace GeekBurger.Production.Repository
{
    public class ProductionAreaRepository : IProductionAreaRepository
    {

        private ProductionContext _context;

        public ProductionAreaRepository(ProductionContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductionArea> GetAvailableProductionAreas()
        {
            return _context.ProductionAreas?.Include(pa => pa.ProductionAreaRestrictions)
                                                .ThenInclude(r => r.Restriction)
                                                .ToList();
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
            _context.SaveChanges();
        }
    }
}
