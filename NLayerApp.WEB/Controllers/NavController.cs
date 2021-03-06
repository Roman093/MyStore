﻿using AutoMapper;
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
        ICategoryService categoryService;
        public NavController(ICategoryService serv)
        {
            categoryService = serv;
        }

        public PartialViewResult Menu(CategoryDTO category = null)
        {
            IEnumerable<ProductDTO> productDtos = categoryService.GetProducts();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, ProductViewModel>()).CreateMapper();
            var categors = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productDtos);
            return PartialView(categors);
        }
    }
}