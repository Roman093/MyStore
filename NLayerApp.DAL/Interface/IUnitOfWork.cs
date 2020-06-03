using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Interface
{
   public interface IUnitOfWork:IDisposable
    {
        IRepository<Product> Products { get; }
        ICartRepository<CartLine> Carts { get; }
        IRepository<Category> Categorys { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}
