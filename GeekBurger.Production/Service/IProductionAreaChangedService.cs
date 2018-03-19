using GeekBurger.Production.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace GeekBurger.Production.Service
{
    public interface IProductionAreaChangedService
    {
        void SendMessagesAsync();
        void AddToMessageList(IEnumerable<EntityEntry<ProductionArea>> changes);
    }
}