using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Formicary.Hosting
{
    public interface IStartup
    {
        
        void ConfigureHost(IConfigurationBuilder configurationBuilder);
        void ConfigureApplication(HostBuilderContext context, IConfigurationBuilder configurationBuilder);
        void ConfigureServices(HostBuilderContext context, IServiceCollection services);
    }
}