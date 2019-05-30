using System.Threading.Tasks;
using Formicary.Hosting;

namespace Formicary.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = FormicaryHostBuilder
                .Create(new Startup(args))
                .Build();

            await host.StartAsync();
        }
    }
}