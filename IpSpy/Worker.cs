using IpSpy.Services;
using Microsoft.Extensions.Options;

namespace IpSpy
{
    public class Worker : BackgroundService
    {
        private readonly IIpSpyService ipSpyService;
        private readonly ILogger<Worker> logger;
        private readonly IMailService mailService;
		private readonly IpSpyConfig ipSpyConfig;
		private string ipAddress = "";

		public Worker(
            ILogger<Worker> logger, 
            IIpSpyService ipSpyService, 
            IMailService mailService,
			IOptions<IpSpyConfig> appSettings)
        {
            this.logger = logger;
            this.ipSpyService = ipSpyService;
            this.mailService = mailService;
			ipSpyConfig = appSettings.Value;
		}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var newIp = await ipSpyService.GetIPAsync();
                if (ipAddress != newIp)
                {
                   mailService.SendMail(newIp);
                   ipAddress = newIp;
                }

                logger.LogInformation("IpSpy service running at: {time} {ip}", DateTimeOffset.Now, newIp);
                await Task.Delay(ipSpyConfig.CheckInterval * 1000 * 60, stoppingToken);
            }
        }
    }
}