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
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService serv)
        {
            categoryService = serv;
        }

        public ActionResult Index(/*CategoryViewModel category*/)
        {
            IEnumerable<ProductDTO> productDtos = categoryService.GetProducts();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var categors = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDtos);


            return View(categors);



            //var categoryDto = new CategoryDTO { ProductId = category.ProductId, Name = category.Name };
            //categoryService.Create(categoryDto);

            //return PartialView(category);





            //IEnumerable<CategoryDTO> categories = categoryService.GetCategorys()
            //    .Select(product => product.Name)
            //    .Distinct()
            //    .OrderBy(x => x);
            //return PartialView(categories);
        }
    }
}