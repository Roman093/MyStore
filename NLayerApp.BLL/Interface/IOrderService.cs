using NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Interface
{
   public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        //PhoneDTO GetPhone(int? id);
        //IEnumerable<PhoneDTO> GetPhones();
        void Dispose();
    }
}
