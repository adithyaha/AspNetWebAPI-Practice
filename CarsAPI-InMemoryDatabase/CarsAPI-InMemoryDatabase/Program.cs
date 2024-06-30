using CarsAPI_InMemoryDatabase.Repository;
using CarsAPI_InMemoryDatabase.Repository.Services;

namespace CarsAPI_InMemoryDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<ICarsRepository, CarsRepository>();

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
