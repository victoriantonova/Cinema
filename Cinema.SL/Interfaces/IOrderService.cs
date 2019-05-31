using Cinema.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.SL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Orders> GetSeance(int entered_idseance);
        IEnumerable<Orders> GetUserOrders(string username);
        IEnumerable<Orders> getOrdersUs(string username);
        IEnumerable<Orders> getOrders();
        IEnumerable<Orders> getOrdersId(string iduser);
        bool IsPaid(int entered_idorder);
        void UpdateOrder(int id);
        void CreateOrder(Orders orders);
        void DeleteOrder(int id);
    }
}
