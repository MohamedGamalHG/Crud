using Crud.Data;
using Crud.Dtos;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly ApplicationDbContext _context;
        public ProductsServices(ApplicationDbContext context) { _context = context; }
        public IEnumerable<ViewProductDto> AllProducts()
        {
            try
            {
                var Products = _context.products.Include(pr => pr.SubCategory).ToList();

                List<ViewProductDto> sub = new List<ViewProductDto>();
                foreach (var product in Products)
                {
                    sub.Add(new ViewProductDto { Name = product.Name, Id = product.Id, Description = product.Description,subCategoryName= product.SubCategory.Name });
                }
                if (Products is null)
                    throw new Exception("test");
                else
                    return sub;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Product Store(StoreProductDto product)
        {
            try
            {
                Product Product = new Product { Name = product.Name, Description = product.Description, subcategory_id = product.SubCategoryId };
                _context.products.Add(Product);
                Int64 numberRows = _context.SaveChanges();
                if (numberRows > 0)
                    return Product;
                else
                    throw new Exception("there no faild add");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public ViewProductDto GetById(int id)
        {
            try
            {

                Product product = _context.products.Include(pro => pro.SubCategory).SingleOrDefault(i => i.Id == id);
                ViewProductDto st = new ViewProductDto { Name = product.Name, Description = product.Description, Id = product.Id,subCategoryName = product.SubCategory.Name };
                if (product is not null)
                    return st;
                else
                    throw new Exception("there is no category by this id ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public bool Update(StoreProductDto Pro, int id)
        {
            Product product = _context.products.SingleOrDefault(i => i.Id == id);
            if (product is not null)
            { 
                product.Name = Pro.Name;
                product.subcategory_id = Pro.SubCategoryId;
                product.Description = Pro.Description;
                Int64 numberRows = _context.SaveChanges();
                if (numberRows > 0)
                    return true;
                else
                    throw new Exception("there no faild add");
            }
            else
                throw new Exception("there is no category by this id ");
        }

        public bool Delete(int id)
        {
            Product product = _context.products.SingleOrDefault(i => i.Id == id);
            if (product is not null)
            {
                _context.Remove(product);
                Int64 numberRows = _context.SaveChanges();
                if (numberRows > 0)
                    return true;
                else
                    throw new Exception("there no faild add");
            }
            else
                throw new Exception("there is no category by this id ");

        }
    }
}
