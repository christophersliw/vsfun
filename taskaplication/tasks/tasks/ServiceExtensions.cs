using data;
using Microsoft.Extensions.DependencyInjection;

namespace tasks
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ITaskServices, TaskServices>();
            
            return services;
        }
    }
}