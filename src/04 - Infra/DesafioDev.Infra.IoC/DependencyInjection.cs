using DesafioDev.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioDev.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RequestToCommandMapping));

            serv

            return services;
        }
    }
}
