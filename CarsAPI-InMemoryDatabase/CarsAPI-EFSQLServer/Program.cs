using CarsAPI_EFSQLServer.Data;
using CarsAPI_EFSQLServer.Repository.Service;
using CarsAPI_EFSQLServer.Repository;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI_EFSQLServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<CarDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CarConnection"));
            });
            builder.Services.AddScoped<ICarRepository, CarRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
