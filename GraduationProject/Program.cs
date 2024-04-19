using GraduationProject.Models;
using GraduationProject.Services;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            /*builder.Services.AddScoped<IImportDataFromExcelService, ImportDataFromExcelService>();
            // Add services to the container.

            var serviceProvider = builder.Services.BuildServiceProvider();

            var importService = serviceProvider.GetRequiredService<IImportDataFromExcelService>();

            importService.ReadCsvFile();*/


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().DisallowCredentials());

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
