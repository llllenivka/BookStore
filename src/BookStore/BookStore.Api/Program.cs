using BookStore.Api.Application.DTO.Vlidators;
using BookStore.Api.Application.Interfaces;
using BookStore.Api.Application.Mapping;
using BookStore.Api.Application.Services;
using BookStore.Api.Infrastructure.Data;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace BookStore.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddControllers()
            .AddFluentValidation(v =>
            {
                v.RegisterValidatorsFromAssemblyContaining<BookRequestDtoValidator>();
                v.AutomaticValidationEnabled = true;
            });
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<BookStoreDbContext>( options=>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("BookStoreDb"));
        });
        builder.Services.AddScoped<IBookService, BookService>();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp",
                policy => policy
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        
        
        var app = builder.Build();
        app.UseCors("AllowReactApp");
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.Run();
    }
}