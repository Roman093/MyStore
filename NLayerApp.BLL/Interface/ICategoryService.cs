using NLayerApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Interface
{
    public interface ICategoryService
    {
        void Create(CategoryDTO categoryDto);
        CategoryDTO GetCategory(int? id);
        IEnumerable<ProductDTO> GetProducts();
        //IEnumerable<CategoryDTO> GetCategorys();

        void Dispose();
    }
}
