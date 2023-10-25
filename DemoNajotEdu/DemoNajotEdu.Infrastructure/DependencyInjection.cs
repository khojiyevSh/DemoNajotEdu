using DemoNajotEdu.Domain.Enums;
using DemoNajotEdu.Infrastructure.Abstractions;
using DemoNajotEdu.Infrastructure.Persistence;
using DemoNajotEdu.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DemoNajotEdu.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDcontext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITokenService, JWTService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                   options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateIssuerSigningKey = true,
                     ValidateLifetime = true,
                     ValidateAudience = true,
                     ValidIssuer = configuration["JWT:ValidIssuer"],
                     ValidAudience = configuration["JWT:validAudiense"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                 };
             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminsAction", polisy =>
                {
                    polisy.RequireClaim("Role", UserRole.Admin.ToString());
                });
            });
            return services;
        }
    }
}
