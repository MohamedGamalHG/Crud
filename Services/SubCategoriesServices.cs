using Crud.Data;
using Crud.Dtos;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Services
{
    public class SubCategoriesServices : ISubCategoriesServices
    {
        private readonly ApplicationDbContext _context;
        public SubCategoriesServices(ApplicationDbContext context) { _context = context; }
        public IEnumerable<ViewSubCategoryDto> AllSubCategories()
        {
            try
            {
                var SubCategoryies = _context.subCategories.Include(cat => cat.category).ToList();
                List<ViewSubCategoryDto> sub  = new List<ViewSubCategoryDto>(); 
                foreach (var subCategory in SubCategoryies)
                {
                    sub.Add(new ViewSubCategoryDto { Name = subCategory.Name, Id = subCategory.Id, category_name = subCategory.category.Name });
                }
                if (SubCategoryies is null)
                    throw new Exception("test");
                else
                    return sub;

            }
            catch (Exception ex)
            {
                throw new Exception("test");
            }
        }

        public SubCategory Store(StoreSubCategoryDto subcat)
        {
            try
            {
                SubCategory subCategory = new SubCategory { Name = subcat.Name,category_id = subcat.CategoryId };
                _context.subCategories.Add(subCategory);
                Int64 numberRows = _context.SaveChanges();
                if (numberRows > 0)
                    return subCategory;
                else
                    throw new Exception("there no faild add");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public ViewSubCategoryDto GetById(int id)
        {
            try
            {

                SubCategory SubCategory = _context.subCategories.Include(cat => cat.category).SingleOrDefault(i => i.Id == id);
                ViewSubCategoryDto st = new ViewSubCategoryDto { Name = SubCategory.Name, category_name = SubCategory.category.Name, Id = SubCategory.Id };
                if (SubCategory is not null)
                    return st;
                else
                    throw new Exception("there is no category by this id ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public bool Update(StoreSubCategoryDto SubCat, int id)
        {
            SubCategory SubCategory = _context.subCategories.SingleOrDefault(i => i.Id == id);
            if (SubCategory is not null)
            {
                SubCategory.Name = SubCat.Name;
                SubCategory.category_id = SubCat.CategoryId;
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
            SubCategory SubCategory = _context.subCategories.SingleOrDefault(i => i.Id == id);
            if (SubCategory is not null)
            {
                _context.Remove(SubCategory);
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
