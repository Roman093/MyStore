using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interface;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.BLL.Service
{
    public class CartService : ICartService
    {
        private string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        //IOrderService order {get; set: }
        IUnitOfWork Database { get; set; }

        public CartService(IUnitOfWork uow)
        {
            //order = orderService;
            Database = uow;
        }

        public void AddCart(CartLineDTO cart)
        {
            Product product = Database.Products.Get(cart.ProductId);

            if (product == null)
                throw new ValidationException("Корзина пуста", "");

            CartLine cartLine = new CartLine
            {
                ProductId = product.Id
                //Product = ++
            };
            Database.Carts.Create(cartLine);
            Database.Save();
        }

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Корзина пуста", "");
            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Товар не найден", "");
            return new ProductDTO { Company = product.Company,
                Id = product.Id, Name = product.Name, Price = product.Price, /*Category=product.Category,*/ /*Details = product.Details,*/
                img = product.img };
        }
        public IEnumerable<OrderDTO> GetProduct()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        //public CartService GetCart()
        //{
        //    var cart = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
        //    return cart.Mapp<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
        //}
    }
}

