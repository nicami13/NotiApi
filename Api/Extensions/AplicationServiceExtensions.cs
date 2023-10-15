using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public class AplicationServiceExtensions
    {
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.UnitOfwork;

namespace ApiAnimals.Extensions
{
    public static class AplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)=>
            services.AddCors(options =>{
                options.AddPolicy(
                    "corspolicy",
                    builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });
    public static void ConfigureRatelimiting(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(options =>{
            options.EnableEndpointRateLimiting=true;
            options.StackBlockedRequests=false;
            options.HttpStatusCode=429;
            options.RealIpHeader="X-Reañ-IP";
            options.GeneralRules =new List<RateLimitRule>
            {
                new RateLimitRule{
                    Endpoint="*",
                    Period="10s",
                    Limit=2
                }
            };
        });   
    }

    public static void AddAplicationServices(this IServiceCollection services){
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    }


}
    }
}