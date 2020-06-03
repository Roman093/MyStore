using NLayerApp.DAL.Entities;
using System.Data.Entity;


namespace NLayerApp.DAL.EF
{
    public class MobileContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CartLine> Carts { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }

        static MobileContext()
        {
            Database.SetInitializer<MobileContext>(new StoreDbInitializer());
        }
        public MobileContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
