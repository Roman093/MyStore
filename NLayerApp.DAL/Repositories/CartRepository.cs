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
    public class CartRepository : IRepository<CartLine>
    {
        private MobileContext db;
        public CartRepository(MobileContext context)
        {
            this.db = context;
        }
        public IEnumerable<CartLine> GetAll()
        {
            return db.Carts.Include(o => o.Product);
        }
        public CartLine Get(int id)
        {
            return db.Carts.Find(id);
        }
        public void Create(CartLine cart)
        {
            db.Carts.Add(cart);
        }
        public void Update(CartLine cart)
        {
            db.Entry(cart).State = EntityState.Modified;
        }
        public IEnumerable<CartLine> Find(Func<CartLine, Boolean> predicate)
        {
            return db.Carts.Include(o => o.Product).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            CartLine cart = db.Carts.Find(id);
            if (cart != null)
                db.Carts.Remove(cart);
        }
    }
}



//        //private List<CartLine> lineCollection = new List<CartLine>();

//        private MobileContext db;
//        public CartRepository(MobileContext context)
//        {
//            this.db = context;
//    }
//    //}
////}
//public IEnumerable<CartLine> GetAll()
//{
//    return db.Carts;
//}
//public CartLine Get(int id)
//{
//    return db.Carts.Find(id);
//}
//public void Create(CartLine book)
//{
//    db.Carts.Add(book);
//}
//public void Update(CartLine book)
//{
//    db.Entry(book).State = EntityState.Modified;
//}
//public IEnumerable<CartLine> Find(Func<CartLine, Boolean> predicate)
//{
//    return db.Carts.Where(predicate).ToList();
//}
//public void Delete(int id)
//{
//    Product book = db.Products.Find(id);
//    if (book != null)
//        db.Products.Remove(book);
//}
//    }
//}



//public void AddItem(Product product, int quantity)
//{
//    CartLine line = lineCollection
//        .Where(p => p.Product.Id == product.Id)
//        .FirstOrDefault();

//    if (line == null)
//    {
//        lineCollection.Add(new CartLine
//        {
//            Product = product,
//            Quantity = quantity
//        });
//    }
//    else
//    {
//        line.Quantity += quantity;
//    }
//}

//public void RemoveLine(Product product)
//{
//    lineCollection.RemoveAll(l => l.Product.Id == product.Id);
//}

//public decimal ComputeTotalValue()
//{
//    return lineCollection.Sum(e => e.Product.Price * e.Quantity);

//}
//public void Clear()
//{
//    lineCollection.Clear();
//}

//public IEnumerable<CartLine> Lines
//{
//    get { return lineCollection; }
//}
//    }
//}
