using System.Text;
using BookStore.Application.DTO.Vlidators;
using BookStore.Application.Interfaces;
using BookStore.Application.Services;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookStoreDbContext>( options=>
        {
            options.UseNpgsql(configuration.GetConnectionString("BookStoreDb"));
        });
        return services;
    }
    
    public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration,
        IConfigurationSection jwtConfig)
    {
        services.Configure<JwtOptions>(jwtConfig);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtConfig["SecretKey"]))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["kakoi-to-kluch"];
                        return Task.CompletedTask;
                    }
                };
            });
        
        // services.AddAuthorization(options =>
        // {
        //     options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
        // });
        return services;
    }

    public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowReactApp",
                policy => policy
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        
        return services;
    }


    public static IServiceCollection AddValidationAndMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BookStore.Application.Mapping.MappingProfile));

        services.AddEndpointsApiExplorer();
        services.AddControllers()
            .AddFluentValidation(v =>
            {
                v.RegisterValidatorsFromAssemblyContaining<BookRequestDtoValidator>();
                v.AutomaticValidationEnabled = true;
            });
        
        return services;
    }
}