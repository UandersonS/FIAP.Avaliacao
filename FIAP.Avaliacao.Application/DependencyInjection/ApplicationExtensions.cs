using FIAP.Avaliacao.Application.Services;
using FIAP.Avaliacao.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FIAP.Avaliacao.Application.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IAesCryptographyService, AesCryptographyService>();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
