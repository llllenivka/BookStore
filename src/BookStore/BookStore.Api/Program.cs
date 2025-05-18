using BookStore.Api.Extensions;

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
        app.UseCustomMiddleware();
        app.MapControllers();

        app.Run();
    }
}