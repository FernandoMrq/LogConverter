using CandidateTesting.FernandoMarques.Core.Application;
using CandidateTesting.FernandoMarques.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTesting.FernandoMarques.Consoles
{
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
