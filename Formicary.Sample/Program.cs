using System.Threading.Tasks;
using Formicary.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Formicary.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = FormicaryHostBuilder
                .Create(new Startup(args))
                .ConfigureLogging(builder => builder.AddConsole())
                .Build();

            await host.StartAsync();
        }
    }
}