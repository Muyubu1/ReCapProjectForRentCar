using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Bu metot, uygulama için gerekli servisleri yapılandırır.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();  // MVC kullanımı için eklenir
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // TokenOptions'ı appsettings.json'dan al
        var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        // JWT Authentication ekle
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                };
            });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin());
        });
    }

    // Bu metot, uygulama için HTTP isteklerini yönetir.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication(); // Authentication middleware'i ekle
        app.UseAuthorization();  // Authorization middleware'i ekle

        app.UseCors("AllowOrigin"); // Cors ekle

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();  // API Controller rotalarını belirler
        });
    }
}
