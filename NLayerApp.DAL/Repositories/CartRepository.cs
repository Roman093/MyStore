using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class CartRepository : ICartRepository<CartLine>
    {
        private MobileContext db;
        public CartRepository(MobileContext context)
        {
            this.db = context;
        }

        public void Create(CartLine cartItem)
        {
            db.Carts.Add(cartItem);
            //db.SaveChanges();
        }

        public void Delete(int id)
        {
            CartLine item = db.Carts.Find(id);
            if (item != null)
                db.Carts.Remove(item);
        }

        public void EmptyCart(string shoppingCartId)
        {
            var cartItems = db.Carts.Where(cart => cart.CartId == shoppingCartId);
            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            //db.SaveChanges();
        }

        //public CartLine GetById(int id, string shoppingCartId)
        //{
        //    var cartItem = db.Carts.FirstOrDefault(
        //                    cart => cart.CartId == shoppingCartId
        //                    /*&& cart.Id == id*/);
        //    return cartItem;
        //}

        public CartLine GetById(int id)
        {
            return db.Carts.Find(id);
        }

        public IEnumerable<CartLine> GetCartItems(string shoppingCartId)
        {
            var cartItems = db.Carts.Where(cart => cart.CartId == shoppingCartId).ToList();
            return cartItems;
        }

        public int GetQuantity(string shoppingCartId)
        {
            int? quantity = db.Carts.Where(x => x.CartId == shoppingCartId).Select(x => (int?)x.Quantity).Sum();
            return quantity ?? 0;
        }

        public CartLine GetMatchingCart(string shoppingCartId, Product product)
        {
            var cartItem = db.Carts.FirstOrDefault(x => x.CartId == shoppingCartId && x.ProductId == product.Id);

            return cartItem;
        }

        public decimal GetTotalPrice(string shoppingCartId)
        {
            decimal? total = db.Carts.Where(x => x.CartId == shoppingCartId).Sum(x => (int?)x.Quantity * x.Product.Price);

            return total ?? 0;
        }

        public void Update(CartLine cartItem)
        {
            var result = db.Carts.FirstOrDefault(x => x.Id == cartItem.Id);

            if (result != null)
            {
                result.Quantity = cartItem.Quantity;
                //db.SaveChanges();
            }
        }
    }
}



//        public IEnumerable<CartLine> GetAll()
//        {
//            return db.Carts.Include(o => o.Product);
//        }
//        public CartLine Get(int id)
//        {
//            return db.Carts.Find(id);
//        }
//        public void Create(CartLine cart)
//        {
//            db.Carts.Add(cart);
//        }
//        public void Update(CartLine cart)
//        {
//            db.Entry(cart).State = EntityState.Modified;
//        }
//        public IEnumerable<CartLine> Find(Func<CartLine, Boolean> predicate)
//        {
//            return db.Carts.Include(o => o.Product).Where(predicate).ToList();
//        }
//        public void Delete(int id)
//        {
//            CartLine cart = db.Carts.Find(id);
//            if (cart != null)
//                db.Carts.Remove(cart);
//        }
//    }
//}



