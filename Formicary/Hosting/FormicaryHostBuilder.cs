using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Formicary.Hosting
{
    public class FormicaryHostBuilder
    {
        private const string ENV_PREFIX = "FORMICARY_";

        public static IHostBuilder Create(IStartup startup) => new FormicaryHostBuilder(startup).Create();

        private readonly IStartup _startup;

        public FormicaryHostBuilder(IStartup startup)
        {
            _startup = startup;
        }

        public IHostBuilder Create() => new HostBuilder()
            .ConfigureHostConfiguration(_startup.ConfigureHost)
            .ConfigureAppConfiguration(_startup.ConfigureApplication)
            .ConfigureServices(ConfigureServices);

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // TODO: Formicary 서비스 등록
            _startup.ConfigureServices(context, services);
        }
    }
}