using Microsoft.EntityFrameworkCore;
using WordSearchAPI.Data;

namespace WordSearchAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder Builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            Builder.Services.AddControllers();

            Builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(Builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21))));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            Builder.Services.AddEndpointsApiExplorer();
            Builder.Services.AddSwaggerGen();

            WebApplication Application = Builder.Build();

            // Configure the HTTP request pipeline.
            if (Application.Environment.IsDevelopment())
            {
                Application.UseSwagger();
                Application.UseSwaggerUI();
            }

            Application.UseHttpsRedirection();
            Application.UseAuthorization();
            Application.MapControllers();
            Application.Run();
        }
    }
}
