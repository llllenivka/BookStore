using BookStore.Application.DTO.Vlidators;
using BookStore.Application.Interfaces;
using BookStore.Application.Mapping;
using BookStore.Application.Services;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddAutoMapper(typeof(BookStore.Application.Mapping.MappingProfile));
        builder.Services.AddControllers()
            .AddFluentValidation(v =>
            {
                v.RegisterValidatorsFromAssemblyContaining<BookRequestDtoValidator>();
                v.AutomaticValidationEnabled = true;
            });
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddDbContext<BookStoreDbContext>( options=>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("BookStoreDb"));
        });

        
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