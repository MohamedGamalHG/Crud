using Crud.Dtos;
using Crud.Models;

namespace Crud.Services
{
    public interface IProductsServices
    {
        IEnumerable<ViewProductDto> AllProducts();
        Product Store(StoreProductDto category);

        ViewProductDto GetById(int id);
        bool Update(StoreProductDto category, int id);
        bool Delete(int id);
    }
}
