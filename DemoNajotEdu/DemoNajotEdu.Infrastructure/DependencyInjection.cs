using DemoNajotEdu.Application.Abstractions;
using DemoNajotEdu.Domain.Enums;
using DemoNajotEdu.Infrastructure.Abstractions;
using DemoNajotEdu.Infrastructure.HashProviders;
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
            services.AddDbContext<ApplicationDbcontext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplecationDbContext, ApplicationDbcontext>();
            services.AddScoped<ITokenService, JWTService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHashProvider,HashProvider>();


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

            services.AddAuthorization(options =>
            {
                options.AddPolicy("TeachersAction", policy =>
                {
                    policy.RequireClaim("Role", UserRole.Teacher.ToString());
                });
            });

            return services;
        }
    }
}
