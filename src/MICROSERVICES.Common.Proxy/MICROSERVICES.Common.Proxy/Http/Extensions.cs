using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MICROSERVICES.Common.Proxy.Http
{
    public static class Extensions
    {
        private static readonly string ProxySectionName = "proxy";
        public static IServiceCollection AddProxyHttp(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var options = configuration.GetOptions<ProxyOptions>(ProxySectionName);

            if (options.Enabled)
            {
                services.AddSingleton<IHttpClient, CustomHttpClient>();
            }

            return services;
        }


    }
}
