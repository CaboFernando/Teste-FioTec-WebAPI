using Infodengue.Domain.Interfaces;
using Infodengue.Infrastructure.Repositories;
using Infodengue.Application.Interfaces;
using Infodengue.Application.Services;

namespace Infodengue.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioAppService, RelatorioAppService>();
            services.AddHttpClient();

            return services;
        }
    }
}
