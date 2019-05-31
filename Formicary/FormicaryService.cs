using System.Threading;
using System.Threading.Tasks;
using Formicary.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Formicary
{
    public class FormicaryService : IHostedService
    {
        private readonly ILogger<FormicaryService> _logger;
        private readonly IOptions<ServiceOptions> _options;

        public FormicaryService(ILogger<FormicaryService> logger, IOptions<ServiceOptions> options)
        {
            _logger = logger;
            _options = options;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}