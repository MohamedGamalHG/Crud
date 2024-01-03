using Crud.Data;
using Crud.Services;
using Microsoft.EntityFrameworkCore;

namespace Crud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICategoriesServices,CategoriesServices>();
            builder.Services.AddScoped<ISubCategoriesServices,SubCategoriesServices>();
            builder.Services.AddScoped<IProductsServices,ProductsServices>();

            builder.Services.AddDbContext<ApplicationDbContext>(
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnnection")
                )
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}