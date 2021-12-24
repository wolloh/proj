using proj.EF;
using Microsoft.EntityFrameworkCore;
namespace proj.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly OrderDBContext context;
        public OrderRepository(OrderDBContext context)
        {
            this.context = context;
        }
        public IEnumerable<EF.Order> GetOrdersList()
        {
            return context.Orders;
        }

        public EF.Order GetOrder(int id)
        {
            return context.Orders.Find(id);
        }

        public void Create(EF.Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Update(EF.Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            EF.Order order = context.Orders.Find(id);
            if (order != null)
                context.Orders.Remove(order);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

