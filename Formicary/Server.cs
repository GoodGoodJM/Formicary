using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Formicary
{
    public class Server
    {
        public class Options
        {
            
        }
        private readonly ILogger _logger;
        private readonly Options _options;

        public Server(ILogger<Server> logger, IOptions<Options> options)
        {
            _logger = logger;
            _options = options.Value;
        }
    }
}