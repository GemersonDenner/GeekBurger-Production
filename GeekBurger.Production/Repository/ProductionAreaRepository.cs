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
            return _context.ProductionAreas?.Include(r => r.Restrictions).ToList();
        }

        public IEnumerable<ProductionArea> GetProductionAreasByRestrictionName(string restrictionName)
        {
            return _context.ProductionAreas?
                                .Include(pa => pa.Restrictions)
                                .Where(w => !w.Restrictions.Any(r => r.Name.Equals(  restrictionName
                                                                                    , StringComparison.InvariantCultureIgnoreCase))
                                                                                  ).ToList();
        }


        public ProductionArea GetProductionAreaById(Guid productionAreaId)
        {
            return _context.ProductionAreas?.Include(r => r.Restrictions)
                                            .FirstOrDefault(productionArea => productionArea.Id == productionAreaId);
        }

        public bool CreateProductionArea(ProductionArea productionArea)
        {
            productionArea.Id = new Guid();
            _context.ProductionAreas.Add(productionArea);

            return true;
        }

        public bool UpdateProductionArea(Guid productionAreaId, ProductionArea updatedProductionArea)
        {
            var productionAreaToUpdate = _context.ProductionAreas?
                                                    .Include(r => r.Restrictions)
                                                    .FirstOrDefault(pa => pa.Id == productionAreaId);

            if (EqualityComparer<ProductionArea>.Default.Equals(productionAreaToUpdate, default(ProductionArea)))
                return false;


            productionAreaToUpdate.Name = updatedProductionArea.Name;
            productionAreaToUpdate.Restrictions = updatedProductionArea.Restrictions;

            _context.ProductionAreas.Update(productionAreaToUpdate);
            
            return true;
        }

        public bool RemoveProductionArea(Guid productionAreaId)
        {
            var productionAreaToDelete = _context.ProductionAreas?.FirstOrDefault(pa => pa.Id == productionAreaId);

            if (EqualityComparer<ProductionArea>.Default.Equals(productionAreaToDelete, default(ProductionArea)))
                return false;

            _context.ProductionAreas?.Remove(productionAreaToDelete);

            return true;
        }



        public void Save()
        {
            //_productionAreaChangedService
            //    .AddToMessageList(_context.ChangeTracker.Entries<ProductionArea>());

            _context.SaveChanges();


            //_productionAreaChangedService.SendMessagesAsync();
        }
    }
}
//