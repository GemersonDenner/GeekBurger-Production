using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using GeekBurger.Production.Model;
using GeekBurger.Production.Service;
using GeekBurger.Production.Contract;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeekBurger.Production.Repository
{
    public class ProductionAreaRepository : IProductionAreaRepository
    {

        private ProductionContext _context;
        private IProductionAreaChangedService _productionAreaChangedService;
        private IOrderFinishedService _orderFinishedService;

        public ProductionAreaRepository(ProductionContext context
                                        , IProductionAreaChangedService productionAreaChangedService
                                        , IOrderFinishedService orderFinishedService
                                       )
        {
            _context = context;
            _productionAreaChangedService = productionAreaChangedService;
            _orderFinishedService = orderFinishedService;
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


        public OrderFinishedMessage PublishOrderFinished(Guid orderFinishedId)
        {

            OrderFinishedMessage orderFinished = new OrderFinishedMessage() { OrderFinishedId = orderFinishedId};

            _orderFinishedService.AddToMessageList(orderFinished);


            Random waitTime = new Random();
            int seconds = waitTime.Next(5 * 1000, 21 * 1000);

            System.Threading.Thread.Sleep(seconds);


            _orderFinishedService.SendMessagesAsync();


            return orderFinished;
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
            _productionAreaChangedService
                .AddToMessageList(_context.ChangeTracker.Entries<ProductionArea>());

            _context.SaveChanges();

            _productionAreaChangedService.SendMessagesAsync();
        }
    }
}
