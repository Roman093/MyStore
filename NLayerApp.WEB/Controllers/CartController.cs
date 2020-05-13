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
        //IUnitOfWork repository;
        //public CartController(IUnitOfWork repo)
        //{
        //    repository = repo;
        //}
        //public ViewResult Index(string returnUrl)
        //{
        //    return View(new CartIndexViewModel
        //    {
        //        Cart = GetCart(),
        //        ReturnUrl = returnUrl
        //    });
        //}
        ////    public RedirectToRouteResult AddToCart(int Id, string returnUrl)
        ////{
        ////    ProductDTO product = repository.Products
        ////        .FirstOrDefault(p => p.Id == Id);

        ////    if (product != null)
        ////    {
        ////        GetCart().AddItem(product, 1);
        ////    }
        ////    return RedirectToAction("Index", new { returnUrl });
        ////}

        ////public RedirectToRouteResult RemoveFromCart(int Id, string returnUrl)
        ////{
        ////    Product product = repository.Products
        ////        .FirstOrDefault(p => p.id == Id);

        ////    if (product != null)
        ////    {
        ////        GetCart().RemoveLine(product);
        ////    }
        ////    return RedirectToAction("Index", new { returnUrl });
        ////}

        //public Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}