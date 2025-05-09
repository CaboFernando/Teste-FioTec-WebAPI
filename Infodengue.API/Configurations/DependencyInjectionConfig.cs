using Infodengue.Domain.Interfaces;
using Infodengue.Infrastructure.Repositories;

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
    }
}
