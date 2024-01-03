using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) {}

        public DbSet<Category> categories { get; set; } = default!;
        public DbSet<SubCategory> subCategories { get; set; } = default!;
        public DbSet<Product> products { get; set; } = default!;
    }
}
