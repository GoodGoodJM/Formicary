using System;
using Formicary.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Formicary.Hosting
{
    public class FormicaryHostBuilder
    {
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
            _startup.ConfigureServices(context, services);
            services
                .AddOptions()
                .Configure<ServiceOptions>(context.Configuration.GetSection("Service"))
                .AddHostedService<FormicaryService>();
            var options = services.BuildServiceProvider().GetService<IOptions<ServiceOptions>>();
            Console.WriteLine(options);
        }
    }
}