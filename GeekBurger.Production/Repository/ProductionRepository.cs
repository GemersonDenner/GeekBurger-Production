using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.Production.Model;

namespace GeekBurger.Production.Repository
{
    public class ProductionRepository : IProductionRepository
    {

        private ProductionContext _context;

        public ProductionRepository(ProductionContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductionArea> GetAvailableProductionAreas()
        {
            return _context.ProductionAreas?.ToList();
        }

        public bool CreateProductionArea(ProductionArea productionArea)
        {
            productionArea.ProductionAreaId = new Guid();
            _context.ProductionAreas.Add(productionArea);

            return true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
