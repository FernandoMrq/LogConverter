using CandidateTesting.FernandoMarques.Adapters.Integration;
using CandidateTesting.FernandoMarques.Adapters.Repository;
using CandidateTesting.FernandoMarques.Core.Application;
using CandidateTesting.FernandoMarques.Core.Business;
using CandidateTesting.FernandoMarques.Core.Domain.Adapters;
using CandidateTesting.FernandoMarques.Core.Domain.Business;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CandidateTesting.FernandoMarques.Infra
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureServices
    {
        public static void AddApplications(IServiceCollection services)
        {
            services.AddScoped<ILogConverterApplication, LogConverterApplication>();
        }

        public static void AddBusiness(IServiceCollection services)
        {
            services.AddScoped<ILogConverterBusiness, LogConverterBusiness>();
        }

        public static void AddAdapters(IServiceCollection services)
        {
            services.AddScoped<IInputAddapter, MinhaCDNAddapter>();
            services.AddScoped<IOutputAddapter, AgoraAddapter>();
        }

        public static void AddServices(ServiceCollection services)
        {
            AddAdapters(services);
            AddBusiness(services);
            AddApplications(services);
        }
    }
}
