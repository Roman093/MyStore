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
        ICartService cartService;

        public CartController(ICartService serv)
        {
            cartService = serv;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewModel
            {
                //Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult Add(int id, string returnUrl)
        {
            ProductDTO product = cartService.GetProduct(id);
            var cart = new CartViewModel { ProductId = product.Id };

            if (product != null)
            {
                GetCart().Add(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            ProductDTO product = cartService.GetProduct(id);
            var cart = new CartViewModel { ProductId = product.Id };

            if (product != null)
            {
                GetCart().Remove(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public CartLineDTO GetCart()
        {
            CartLineDTO cart = (CartLineDTO)Session["Cart"];
            if (cart == null)
            {
                cart = new CartLineDTO();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}