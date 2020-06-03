using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Interface
{
    public interface ICartRepository<T> where T : class
    {
        CartLine GetMatchingCart(string shoppingCartId, Product product);
        void Create(T item);
        void Update(T item);
        //CartLine GetById(int id, string shoppingCartId);
        CartLine GetById(int id);
        void Delete(int id);
        void EmptyCart(string shoppingCartId);
        IEnumerable<CartLine> GetCartItems(string shoppingCartId);
        int GetQuantity(string shoppingCartId);
        decimal GetTotalPrice(string shoppingCartId);
        //void MigrateCart(string userName, string shoppingCartId);

    }
}
