using FIAP.Avaliacao.Infra.Database.Repositories;
using FIAP.Avaliacao.Infra.Database.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Avaliacao.Infra.DependencyInjection
{
    public static class InfraExtensions
    {
        public static void AddInfra(this IServiceCollection services)
        {
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();
        }
    }
}
