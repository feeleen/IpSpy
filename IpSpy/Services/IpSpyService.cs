using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IpSpy.Services
{
    public class IpSpyService : IIpSpyService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private readonly IpSpyConfig ipSpyConfig;
        private readonly ILogger<IpSpyService> logger;

        public IpSpyService(
            HttpClient httpClient,
            IConfiguration config,
            IOptions<IpSpyConfig> appSettings,
            ILogger<IpSpyService> logger)
        {
            this.httpClient = httpClient;
            this.config = config;
            ipSpyConfig = appSettings.Value;
            this.logger = logger;
        }

        public async Task<string> GetIPAsync()
        {
            var url = ipSpyConfig.IPProviderHost;
            return await httpClient.GetStringAsync(url);
        }
    }
}
