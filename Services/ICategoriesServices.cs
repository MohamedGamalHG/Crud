using Crud.Dtos;
using Crud.Models;

namespace Crud.Services
{
    public interface ICategoriesServices
    {
        IEnumerable<Category> AllCategories();
        BaseDto Store(BaseDto category);

        Category GetById(int id);
        bool Update(BaseDto category, int id);

        bool Delete(int id);

    }
}
