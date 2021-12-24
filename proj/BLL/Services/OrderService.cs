using System;
using proj.BLL.Interfaces;
using proj.EF;
using proj.Models;
using proj.BLL.Infastructure;
using AutoMapper;
using proj.BLL.DataTransferObject;
using proj.Repository;
namespace proj.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDBContext _db;
        private readonly IOrderRepository _repository;

        public OrderService(OrderDBContext db, IOrderRepository repository)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public void  MakeOrder(OrderDTO model)
        {
            string error = "";
            if (string.IsNullOrEmpty(model.Name))
            {
                error = "No order data";
                throw new ValidationExceptions(error,model.Name);
            }
            
            Order order = new Order();
            order.Name = model.Name;
            _repository.Create(order);
            
        }
        IEnumerable<OrderDTO> IOrderService.GetOrders()
        {
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<Order, OrderDTO>()
            );
            var mapper = new Mapper(config);
            var orders = _db.Orders;
            var ordersdto = mapper.Map<IEnumerable<Order>, List<OrderDTO>>(_db.Orders);
            return ordersdto ;
        }

        public OrderDTO GetOrder(int id)
        {
            if (id == 0)
                throw new ValidationExceptions("No id", "");
            var order = _db.Orders.Find(id);
            if (order == null)
                throw new ValidationExceptions("No name", "");


            return new OrderDTO { Id=order.Id,Name=order.Name};

        }

        public OrderDTO Update(OrderDTO order)
        {
            if (order.Id == 0)
                throw new ValidationExceptions("No Id ","");
            if (string.IsNullOrEmpty(order.Name))
                throw new ValidationExceptions("No order data","");
            var orderdto = _db.Orders.Find(order.Id);
            if (orderdto is null)
                throw new ValidationExceptions("Incorrect Ordere id","");
            orderdto.Name = order.Name;
            //repository.Update(order);
            //repository.Save();
            _db.Orders.Attach(orderdto);
            _db.SaveChanges();
            return new OrderDTO { Id=orderdto.Id,Name=orderdto.Name};
        }

        public OrderDTO Delete(int id)
        {
            var order = _db.Orders.Find(id);
            if (order is null)
                throw new ValidationExceptions("No data was found","");
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return new OrderDTO { Id = order.Id, Name = order.Name };
        }
    }
}
