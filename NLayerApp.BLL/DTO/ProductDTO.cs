using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public string img { get; set; }
    }
}
