using Microsoft.AspNetCore.Mvc;
using proj.EF;
using proj.Models;
using proj.BLL.Services;
using proj.BLL.Interfaces;
using proj.BLL.DataTransferObject;
using proj.Repository;
using proj.BLL.Infastructure;

namespace proj.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public  class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService serv)
        {
            _orderService = serv ?? throw new ArgumentNullException(nameof(serv));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            try 
            {
                OrderDTO order = _orderService.GetOrder(id);
                return Ok(order);
            }
            catch (ValidationExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Create(OrderModel model)
        {
            try
            {
                _orderService.MakeOrder(model);
            }
            catch (ValidationExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(OrderModel model)
        {
            try
            {
                 _orderService.Update(model);
                //var orderdto1=_orderService.Update(orderdto);
                return Ok("Upgraded Successfully");
            }
            catch(ValidationExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var order = _orderService.Delete(id);
                return Ok(order);
            }
            catch(ValidationExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
