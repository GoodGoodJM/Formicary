using System;
using System.IO;
using Formicary.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Formicary.Sample
{
    public class Startup : IStartup
    {
        private const string ENV_PREFIX = "FORMICARY_SAMPLE_";
        private const string HOST_SETTING_FILE_NAME = "hostsettings";
        private const string APPLICATION_SETTING_FILE_NAME = "appsettings";

        private readonly string[] _args;

        public Startup(string[] args)
        {
            _args = args;
        }

        public void ConfigureHost(IConfigurationBuilder configurationBuilder) => configurationBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"{HOST_SETTING_FILE_NAME}.json")
            .AddEnvironmentVariables(ENV_PREFIX)
            .AddCommandLine(_args);

        public void ConfigureApplication(HostBuilderContext context, IConfigurationBuilder configurationBuilder) => configurationBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"{APPLICATION_SETTING_FILE_NAME}.json")
            .AddJsonFile($"{APPLICATION_SETTING_FILE_NAME}.{context.HostingEnvironment.EnvironmentName}.json", true)
            .AddEnvironmentVariables(ENV_PREFIX)
            .AddCommandLine(_args);

        public void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            foreach (var config in context.Configuration.AsEnumerable())
            {
                Console.WriteLine(config.ToString());
            }
        }
    }
}