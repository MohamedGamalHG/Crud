using Crud.Data;
using Crud.Dtos;
using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ApplicationDbContext _context;
        public CategoriesServices(ApplicationDbContext context) { _context = context; }
        public  IEnumerable<Category> AllCategories()
        {
            try
            {
                List<Category> t =  _context.categories.ToList();
                if (t is null)
                     throw new Exception("test");
                else
                    return t;
                 
            }catch (Exception ex)
            {
                throw new Exception("test");
            }
        }

        public BaseDto Store(BaseDto category)
        {
            try
            {
                Category cat = new Category { Name= category.Name };
                _context.categories.Add(cat); 
                Int64 numberRows =  _context.SaveChanges();
                if (numberRows > 0)                
                    return category;               
                else
                    throw new Exception("there no faild add");
            }catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Category GetById(int id) 
        {
            try
            {

               Category category =  _context.categories.SingleOrDefault(i => i.Id == id);
                if (category is not null)
                    return category;
                else
                    throw new Exception("there is no category by this id ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public  bool Update(BaseDto category, int id) 
        {
            Category cat = _context.categories.SingleOrDefault(i => i.Id == id);
            if(cat  is not null)
            {
                cat.Name = category.Name;
              Int64 numberRows =   _context.SaveChanges();
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
            Category cat = _context.categories.SingleOrDefault(i => i.Id == id);
            if (cat is not null)
            {
                _context.Remove(cat);
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
