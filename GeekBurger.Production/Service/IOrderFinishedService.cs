using GeekBurger.Production.Contract;
using GeekBurger.Production.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace GeekBurger.Production.Service
{
    public interface IOrderFinishedService
    {
        void SendMessagesAsync();
        void AddToMessageList(OrderFinishedMessage orderFinished);
    }
}