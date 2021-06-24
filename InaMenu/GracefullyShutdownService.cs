using InaMenu.MenuDomain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InaMenu
{
    public class GracefullyShutdownService : IHostedService
    {
        ILogger<GracefullyShutdownService> _logger;
        MenuRepository _menuRepository;


        public GracefullyShutdownService(
            ILogger<GracefullyShutdownService> logger,
            MenuRepository menuRepository
            )
        {
            _logger = logger;
            _menuRepository = menuRepository;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("start");
            await _menuRepository.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("stop");
            await _menuRepository.StopAsync(cancellationToken);
        }
    }
}
