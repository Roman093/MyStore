using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.DTO
{
    public class CartLineDTO
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }

        public void Add(ProductDTO product, int v)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
