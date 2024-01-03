using Crud.Dtos;
using Crud.Models;

namespace Crud.Services
{
    public interface ISubCategoriesServices 
    {
        IEnumerable<ViewSubCategoryDto> AllSubCategories();
        SubCategory Store(StoreSubCategoryDto category);

        ViewSubCategoryDto GetById(int id);
        bool Update(StoreSubCategoryDto category, int id);
        bool Delete(int id);
    }
}
