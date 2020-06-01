using KissLog.Apis.v1.Listeners;
using KissLog.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreIdentity.Config
{
    public static class LogConfig
    {
        public static IApplicationBuilder UseLog(this IApplicationBuilder  application,IConfiguration configuration)
        {
            application.UseKissLogMiddleware(options => {
                options.Listeners.Add(new KissLogApiListener(new KissLog.Apis.v1.Auth.Application(
                    configuration["KissLog.OrganizationId"],
                    configuration["KissLog.ApplicationId"])
                ));
            });


            return application;
        }
    }
}
