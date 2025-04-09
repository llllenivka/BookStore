using BookStore.Api.Application.Mapping;
using BookStore.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<BookStoreDbContext>( options=>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("BookStoreDb"));
        });
        
        var app = builder.Build();
        
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.Run();
    }
}