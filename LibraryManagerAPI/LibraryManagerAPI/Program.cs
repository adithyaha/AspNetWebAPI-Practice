using Microsoft.EntityFrameworkCore;
using LibraryManagerAPI.Data;
using LibraryManagerAPI.Repository;
using LibraryManagerAPI.Repository.Services;

namespace LibraryManagerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));

            builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();

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
