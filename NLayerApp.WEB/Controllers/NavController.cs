using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interface;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.WEB.Controllers
{
    public class NavController : Controller
    {
        IOrderService orderService;
        public NavController(IOrderService serv)
        {
            orderService = serv;
        }

        public PartialViewResult Menu(string category = null)
        {
            IEnumerable<string> categories = orderService.GetProducts()
                .Select(product => product.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}