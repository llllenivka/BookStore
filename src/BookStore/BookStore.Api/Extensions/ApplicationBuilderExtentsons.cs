using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Extensions;

public static class ApplicationBuilderExtentsons
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseCors("AllowReactApp");
        // app.MapControllers();

        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}