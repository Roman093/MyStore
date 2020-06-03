using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interface;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interface;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ViewResult Index(/*string returnUrl*/)
        {
            IEnumerable<OrderDTO> orderDtos = cartService.GetProduct();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(Database.Orders.GetAll());


            //var cart = cartService.GetCart(returnUrl)

            //var cartView = new CartViewModel
            //{
            //    CartItems = cart.GetProduct(),


            //CartTotal = cart.GetTotalPrice()
            //Cart = GetCart(),
            //ReturnUrl = returnUrl
            //};
            return View(cartView);
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