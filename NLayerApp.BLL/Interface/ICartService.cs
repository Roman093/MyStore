using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.BLL.Interface
{
    public interface ICartService
    {
        void AddCart(CartLineDTO cart);
        ProductDTO GetProduct(int? id);
        IEnumerable<OrderDTO> GetProduct();

        void Dispose();
        //CartService GetCart(HttpContextBase context);



        //CartService GetCart(Controller controller);
        //void AddToCart(ProductDTO product);
        //CartLineDTO GetById(int id);
        //int RemoveFromCart(int id);
        //void EmptyCart();
        //IEnumerable<CartLineDTO> GetCartItems();
        //int GetQuantity();
        //decimal GetTotalPrice();
        //void CreateOrder(OrderDTO order);
        //string GetCartId(HttpContextBase context);
    }
}
