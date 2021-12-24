using System;
using proj.BLL.Interfaces;
using proj.EF;
using proj.Models;
using proj.BLL.Infastructure;
using AutoMapper;
using System.Linq;
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
        public void MakeOrder(OrderModel model)
        {
            string error = "";
            if (string.IsNullOrEmpty(model.Name))
            {
                error = "Invalid data";
                throw new ValidationExceptions(error,model.Name);
            }
            if (string.IsNullOrEmpty(model.Customer))
            {
                error = "Invalid customer Name";
                throw new ValidationExceptions(error, model.Name);
                
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                error = "Invalid description";
                throw new ValidationExceptions(error, model.Name);
            }
            //if(string.IsNullOrEmpty(model.Status))
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<OrderModel, Order>()
            );
            var mapper = new Mapper(config);
            var order = mapper.Map<OrderModel, Order>(model);
            //Order order = new Order();
            //order.OrderName = model.Name;
            _repository.Create(order);
            
        }
        IEnumerable<OrderDTO> IOrderService.GetOrders()
        {
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<Order, OrderDTO>()
            );
            var mapper = new Mapper(config);
            //var orders = _db.Orders;
            var ordersdto = mapper.Map<IEnumerable<Order>, List<OrderDTO>>(_repository.GetOrdersList());
            return ordersdto ;
        }

        public OrderDTO GetOrder(int id)
        {
            var order = _repository.GetOrder(id);
            if (id <= 0 || order==null)
                throw new ValidationExceptions("No id", "");
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<Order, OrderDTO>()
            );
            var mapper = new Mapper(config);
            var orderdto = mapper.Map<Order, OrderDTO>(order);
            return orderdto;

        }

        public void Update(OrderModel model)
        {
            if (model.Id <= 0)
                throw new ValidationExceptions("No Id ","");
            //var order_db= _repository.GetOrder(model.Id);
            if (string.IsNullOrEmpty(model.Customer))
                throw new ValidationExceptions("No customer", "");
            if (string.IsNullOrEmpty(model.Performer) && model.Status!="Free")
                throw new ValidationExceptions("Invalid status", "");
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<OrderModel, Order>()
            );
            var mapper = new Mapper(config);
            Order order = mapper.Map<OrderModel, Order>(model);
            
            /* if (!string.IsNullOrEmpty(order.Status) && order.Status == "Finished")
             {
                 _repository.Delete(order.Id);
                 _repository.Save();
             }
             else
             {
                 if (!string.IsNullOrEmpty(model.Performer))
                 {
                     order.Status = "In progress";
                 }
                 _repository.Update(order);
                 _repository.Save();
             }*/
            _repository.Update(order);
            _repository.Save();
             
        }

        public OrderDTO Delete(int id)
        {
            var order = _repository.GetOrder(id);
            if (order is null || id<=0)
                throw new ValidationExceptions("No data was found","");
            _repository.Delete(id);
            _repository.Save();
            var config = new MapperConfiguration(cfg =>
              cfg.CreateMap<Order, OrderDTO>()
            );
            var mapper = new Mapper(config);
            var orderdto = mapper.Map<Order, OrderDTO>(order);
            return orderdto;
        }
    }
}
