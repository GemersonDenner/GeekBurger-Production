using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GeekBurger.Production.Service
{
    /// <summary>
    /// Interface que será utilizada para implementar métodos relacionados ao recebimento de novos pedidos.
    /// </summary>
    public interface IPaidOrderService
    {
        void SubscribeToTopic(string topicName, List<ProductionArea> productionAreas);
    }
}