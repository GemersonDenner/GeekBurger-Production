using GeekBurger.Production.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace GeekBurger.Production.Service
{
    /// <summary>
    /// Método utilizado para implementar métodos que serão utilizados para momentos de atualização de área de produção
    /// </summary>
    public interface IProductionAreaChangedService
    {
        void SendMessagesAsync();
        void AddToMessageList(IEnumerable<EntityEntry<ProductionArea>> changes);
    }
}