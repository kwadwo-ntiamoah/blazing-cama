using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.Text;

namespace Api.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<JWTService>();
            services.AddScoped<MiscService>();
            services.AddScoped<ShopService>();
            services.AddScoped<UserSubscriptionService>();
            services.AddScoped<HubtelService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<UserMgmtService>();

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(config.GetConnectionString("DbConnection")));

            services.AddScoped<CategoryRepo>();
            services.AddScoped<DayRepo>();
            services.AddScoped<ItemRepo>();
            services.AddScoped<OrderRepo>();
            services.AddScoped<PaymentRepo>();
            services.AddScoped<ProgrammeRepo>();
            services.AddScoped<SubscriptionRepo>();
            services.AddScoped<UserSubscriptionRepo>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                var key = config.GetValue<string>("JWT:Key");
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = config.GetValue<string>("JWT:Issuer"),
                    ValidAudience = config.GetValue<string>("JWT:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            return services;
        }
    }
}
