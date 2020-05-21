using NLayerApp.BLL.BusinessModels;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interface;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interface;
using System;
using System.Collections.Generic;
using AutoMapper;


namespace NLayerApp.BLL.Service
{
    public class OrderService : IOrderService
    {
        
      IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Product product = Database.Products.Get(orderDto.ProductId);

            if (product == null)
                throw new ValidationException("Товар не найден", "");

            decimal sum = new Discount(0.1m).GetDiscountedPrice(product.Price);
            Order order = new Order
            {
                Date = DateTime.Now,
                Address = orderDto.Address,
                ProductId = product.Id,

                Sum = sum,
                PhoneNumber = orderDto.PhoneNumber
            };
            Database.Orders.Create(order);
            Database.Save();
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());

        }
        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id товара", "");
            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Товар не найден", "");
            return new ProductDTO { Company = product.Company, Id = product.Id, Name = product.Name, Price = product.Price, Category=product.Category, img=product.img };

        }
        public void Dispose()
        {
        Database.Dispose();
        }
    }
}
