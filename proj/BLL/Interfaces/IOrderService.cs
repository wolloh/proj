using System.Collections.Generic;
using proj.Models;
using proj.BLL.DataTransferObject;
namespace proj.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderModel order);
        OrderDTO GetOrder(int id);
        IEnumerable<OrderDTO> GetOrders();
        void Update(OrderModel order);
        OrderDTO Delete(int id);
    }
}
