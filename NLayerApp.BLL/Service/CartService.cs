using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.BLL.Interface;
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

        public CartLineDTO GetProduct(int? id)
        {
            throw new NotImplementedException();
        }

        ProductDTO ICartService.GetProduct(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<ProductDTO> GetProducts()
        //{
        //    //if (id == null)
        //    //    throw new ValidationException("Не установлено id товара", "");
        //    //var product = Database.Products.Get(id.Value);
        //    ////if (product == null)
        //    ////    throw new ValidationException("Товар не найден", "");
        //    return new ProductDTO { Company = product.Company, Id = product.Id, Name = product.Name, Price = product.Price };
    }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        }
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

//public IEnumerable<CartLine> Lines
//{
//    get { return lineCollection; }
//}
//    }
