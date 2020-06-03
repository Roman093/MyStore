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
    public class CategoryService : ICategoryService
    {
        IUnitOfWork Database { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        //public IEnumerable<CategoryDTO> GetCategorys()
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categorys.GetAll());
        //}

        public void Create(CategoryDTO categoryDto)
        {
            Category category = Database.Categorys.Get(categoryDto.Id);

            Database.Categorys.Create(category);
            Database.Save();
        }

        public CategoryDTO  GetCategory(int? id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id категории", "");
            var category = Database.Products.Get(id.Value);
            //if (category == null)
            //    throw new ValidationException("Категория не найдена", "");
            return new CategoryDTO { Name = category.Name };
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
        }
    }
}
