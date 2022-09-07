using CandidateTesting.FernandoMarques.Core.Application;
using CandidateTesting.FernandoMarques.Infra;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CandidateTesting.FernandoMarques.Consoles
{
    [ExcludeFromCodeCoverage]
    internal class LogConverterConsole
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices.AddServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logConverterApplication = serviceProvider.GetService<ILogConverterApplication>();

            logConverterApplication.StartConverterLog(args);
        }
    }
}
