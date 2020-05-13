using Ninject.Modules;
using NLayerApp.BLL.Service;
using NLayerApp.BLL.Interface;

namespace NLayerApp.WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}