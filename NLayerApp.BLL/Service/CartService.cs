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

namespace NLayerApp.BLL.Service
{
    public class CartService : ICartService
    {

        IUnitOfWork Database { get; set; }

        public CartService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Add(CartLineDTO cartLineDTO, int quantity)
        {
            Product products = Database.Products.Get(cartLineDTO.ProductId);
            if (cartLineDTO == null)
                throw new NotImplementedException();

            //Database.Add(new CartLineDTO
            //{
                CartLine cart = new CartLine
                {
                    ProductId = products.Id,
                    Quantity = cartLineDTO.Quantity,

                    //quantity += quantity;
                };
                Database.Carts.Create(cart);
                Database.Save();
            }  

        public ProductDTO GetProduct(int? id)
        {
            if (id == null)
                throw new NotImplementedException();
            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new NotImplementedException();
            return new ProductDTO { Id = product.Id, Name = product.Name, Price = product.Price };
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

//    {
//        Database.Add(new CartLineDTO
//        {
//            Product = product,
//            Quantity = quantity
//        });
//    }
//    else
//    {
//        line.Quantity += quantity;
//    }
//}







//    public CartLineDTO GetProduct(int? id)
//    {
//        throw new NotImplementedException();
//    }

//    ProductDTO ICartService.GetProduct(int? id)
//    {
//        throw new NotImplementedException();
//    }

//    public IEnumerable<ProductDTO> GetProducts()
//    {
//        throw new NotImplementedException();
//    }

//    public void Dispose()
//    {
//        throw new NotImplementedException();
//    }
//}



//public void AddItem(Product product, int quantity)
//{
//    CartLine line = lineCollection
//        .Where(p => p.Product.Id == product.Id)
//        .FirstOrDefault();

//    if (line == null)
//    {
//        lineCollection.Add(new CartLine
//        {
//            Product = product,
//            Quantity = quantity
//        });
//    }
//    else
//    {
//        line.Quantity += quantity;
//    }
//}

//public void RemoveLine(Product product)
//{
//    lineCollection.RemoveAll(l => l.Product.Id == product.Id);
//}

//public decimal ComputeTotalValue()
//{
//    return lineCollection.Sum(e => e.Product.Price * e.Quantity);

//}
//public void Clear()
//{
//    lineCollection.Clear();
//}

//    public IEnumerable<CartLine> Lines
//    {
//        get { return lineCollection; }
//    }
//}
