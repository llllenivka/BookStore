using System.Text;
using BookStore.Application.DTO.Vlidators;
using BookStore.Application.Interfaces;
using BookStore.Application.Mapping;
using BookStore.Application.Services;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddEndpointsApiExplorer();
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
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
        
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

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
                };
            });
        builder.Services.AddAuthorization();
        
        
        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseCors("AllowReactApp");
        app.MapControllers();

        app.UseAuthentication();
        app.UseAuthorization();

        app.Run();
    }
}