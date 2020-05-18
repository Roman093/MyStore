using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interface;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interface;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.WEB.Controllers
{
    public class CartController : Controller
    {
        IOrderService cartService;

        public CartController(IOrderService serv)
        {
            cartService = serv;
        }

        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            ProductDTO product = cartService.GetProduct(id);
            var cart = new CartViewModel { ProductId = product.Id };

            if (product != null)
            {
                //GetCart().Add(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            ProductDTO product = cartService.GetProduct(id);
            var cart = new CartViewModel { ProductId = product.Id };

            if (product != null)
            {
                //GetCart().Remove(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //public Cart GetCart()
        //{
        //    CartLineDTO cart = (CartLineDTO)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new CartLineDTO();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}