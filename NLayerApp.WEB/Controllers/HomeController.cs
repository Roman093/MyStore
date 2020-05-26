using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NLayerApp.BLL.Interface;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;
using System.Linq;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public int pageSize = 20;
        private PagingInfo category;

        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index(int page = 1)
        {

            IEnumerable<ProductDTO> productDtos = orderService.GetProducts();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDtos);


            return View(products);
        }


        public ActionResult MakeOrder(int? id)
        {
            try
            {

                ProductDTO product = orderService.GetProduct(id);
                var order = new OrderViewModel { ProductId = product.Id };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                var orderDto = new OrderDTO { ProductId = order.ProductId, Address = order.Address, PhoneNumber = order.PhoneNumber };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}
