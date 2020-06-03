using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Category
    {
        //public Category()
        //{
        //    Products = new List<Product>();

        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public string Img { get; set; }
        public Product Product { get; set; }

        //public ICollection<Product> Products { get; set; }
    }
}
