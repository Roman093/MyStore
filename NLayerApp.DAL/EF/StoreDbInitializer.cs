using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.EF
{
   public class StoreDbInitializer : DropCreateDatabaseAlways<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Products.Add(new Product { Name = "Samsung S20", Company = "Samsung", Price = 1000, /*Category = "Phone",*/ Details = "Screen: 6.8', camera: 12Mp", img = "/wwwroot/image/Product/samsung-galaxy-s20-plus.jpg" });
            db.Products.Add(new Product { Name = "IPhone 11", Company = "Apple", Price = 990, Details = "Screen: 6.5', camera: 12Mp", img = "/wwwroot/image/Product/IPhone11pro.jpg" });
            db.Products.Add(new Product { Name = "Xiaomi Note 8", Company = "Xiaomi", Price = 300, Details = "Screen: 6.7', camera: 48Mp", img = "/wwwroot/image/Product/redminote.png" });
            db.Products.Add(new Product { Name = "Samsung Note 10", Company = "Samsung", Price = 1100, Details = "Screen: 6.9', camera: 12Mp", img = "/wwwroot/image/Product/samsung-galaxy-s20-plus.jpg" });
            db.Products.Add(new Product { Name = "AirPods", Company = "Aplle", Price = 400, Details = "Batare: 9 hour, Bluetooth: 2.1", img = "/wwwroot/image/Product/airpods.jpg" });
            db.Products.Add(new Product { Name = "Buds", Company = "Samsung", Price = 300, Details = "Batare: 7 hour, Bluetooth: 2.1", img = "/wwwroot/image/Product/samsung_buds.jpg" });
            //db.Categorys.Add(new Category { Name = "Phone" });
            //db.Categorys.Add(new Category { Name = "Headphones" });
            //db.Categorys.Add(new Category { Name = "Accessories" });
            //db.Categorys.Add(new Category { Name = "Smart Watch" });
            //db.Categorys.Add(new Category { Name = "Laptop" });

            db.SaveChanges();
        }
    }
}
