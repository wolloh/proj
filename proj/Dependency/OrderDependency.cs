using Ninject.Modules;
using proj.BLL.Services;
using proj.BLL.Interfaces;
namespace proj.Dependency
{
    public class OrderDependency:NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
