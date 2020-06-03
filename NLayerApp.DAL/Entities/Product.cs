using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Details { get; set; }
        public string img { get; set; }

        public ICollection<Category> Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
