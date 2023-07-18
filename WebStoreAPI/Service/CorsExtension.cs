using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStoreAPI.Common;

namespace WebStoreAPI.Service
{
    public static class CorsExtension
    {
        public static void ConfiguareCors(this IServiceCollection services, IConfiguration config)
        {

            var configValue = config.GetSection(Constants.CONF_CROSS_ORIGIN).Value;
            string[] CORSComplianceDomains = configValue.Split(",");

            services.AddCors(options =>
            {
                options.AddPolicy("AnotherPolicy",
                    builder =>
                    {
                        builder.WithOrigins(CORSComplianceDomains)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials();
                    });
            });
        }
    }
}
