
using BookStore_Management.DATA;
using BookStore_Management.Helpers;
using BookStore_Management.Repositories;
using BookStore_Management.Repositories.Interfaces;
using BookStore_Management.Services;
using BookStore_Management.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Adding AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            //Add DBContext
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            //configure services& repositories
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService,BookService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
