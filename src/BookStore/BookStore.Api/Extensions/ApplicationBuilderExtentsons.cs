using Microsoft.AspNetCore.CookiePolicy;

namespace BookStore.Api.Extensions;

public static class ApplicationBuilderExtentsons
{
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        app.UseCors("AllowReactApp");
        
        
        // Настройка политики безопасности для куки:
        // - SameSite=Strict - защита от CSRF-атак
        // - HttpOnly - защита от XSS (блокирует доступ через JS)
        // - Secure - передача только по HTTPS
        app.UseCookiePolicy(new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always
        });


        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}