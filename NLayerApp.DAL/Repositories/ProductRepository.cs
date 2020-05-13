using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace NLayerApp.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private MobileContext db;
        public ProductRepository(MobileContext context)
        {
            this.db = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
        public void Create(Product book)
        {
            db.Products.Add(book);
        }
        public void Update(Product book)
        {
            db.Entry(book).State = EntityState.Modified;
        }
        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Product book = db.Products.Find(id);
            if (book != null)
                db.Products.Remove(book);
        }
    }
}
