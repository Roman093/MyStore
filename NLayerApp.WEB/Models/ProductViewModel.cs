using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Models
{
    public class ProductViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public string img { get; set; }
        public string Category { get; set; }
        //public ProductListViewModel productListViewModel { get; set; }
    }
}