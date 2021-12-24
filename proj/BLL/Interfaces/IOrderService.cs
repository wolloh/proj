using System.Collections.Generic;
using proj.Models;
using proj.BLL.DataTransferObject;
namespace proj.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO order);
        OrderDTO GetOrder(int id);
        IEnumerable<OrderDTO> GetOrders();
        OrderDTO Update(OrderDTO order);
        OrderDTO Delete(int id);
    }
}
