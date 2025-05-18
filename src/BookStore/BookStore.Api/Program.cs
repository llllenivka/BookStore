using System.Text;
using BookStore.Api.Extensions;
using BookStore.Application.DTO.Vlidators;
using BookStore.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddServices()
            .AddRepositories()
            .AddDatabase(builder.Configuration)
            .AddSecurityServices(builder.Configuration)
            .AddJwtAuthentication(builder.Configuration)
            .AddCustomCors()
            .AddValidationAndMapping()
            .AddCustomSwagger();
        
        // builder.Services.AddEndpointsApiExplorer();
        
        
        
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