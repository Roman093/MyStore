using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.EF
{
   public class StoreDbInitializer:DropCreateDatabaseIfModelChanges<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            db.Products.Add(new Entities.Product { Name = "Samsung S20", Company = "Samsung", Price = 1000, Category = "Phone", img = "/wwwroot/image/Product/samsung-galaxy-s20-plus.jpg" });
            db.Products.Add(new Entities.Product { Name = "IPhone 11", Company = "Apple", Price = 990, Category = "Phone", img = "/wwwroot/image/Product/IPhone11pro.jpg" });
            db.Products.Add(new Entities.Product { Name = "Xiaomi Note 8", Company = "Xiaomi", Price = 300, Category = "Phone", img = "/wwwroot/image/Product/redminote.png" });
            db.Products.Add(new Entities.Product { Name = "Samsung Note 10", Company = "Samsung", Price = 1100, Category = "Phone", img = "/wwwroot/image/Product/samsung-galaxy-s20-plus.jpg" });
            db.Products.Add(new Entities.Product { Name = "AirPods", Company = "Aplle", Price = 400, Category = "Accessories", img = "/wwwroot/image/Product/airpods.jpg" });
            db.Products.Add(new Entities.Product { Name = "Buds", Company = "Samsung", Price = 300, Category = "Accessories", img = "/wwwroot/image/Product/samsung_buds.jpg" });
            db.Carts.Add(new Entities.CartLine());

            db.SaveChanges();
        }
    }
}
