using AutoMapper;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Interface;
using NLayerApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Mapping
{
    public class ProductMapp
    {
        IOrderService orderService;
        public ProductMapp(IOrderService serv)
        {
            orderService = serv;
            IEnumerable<ProductDTO> productDtos = orderService.GetProducts();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDtos);

            return;
        }
    }
}