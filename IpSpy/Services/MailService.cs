using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IpSpy.Services
{
    public class MailService : IMailService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private readonly IpSpyConfig ipSpyConfig;
        private readonly ILogger<IpSpyService> logger;

        public MailService(
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

        public void SendMail(string ip)
        {
            try
            {
                System.Net.NetworkCredential credential =
                    new System.Net.NetworkCredential(
                        ipSpyConfig.SMTP.Login,
                        ipSpyConfig.SMTP.Password);

                MailMessage message = new MailMessage();
                message.To.Add(ipSpyConfig.Email.To);
                message.Subject = ipSpyConfig.Email.Subject;

                message.From = new MailAddress(ipSpyConfig.SMTP.Login);
                message.Body = string.Format(ipSpyConfig.Email.BodyFormat, ip);

                SmtpClient smtpClient = new SmtpClient(ipSpyConfig.SMTP.Host);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ipSpyConfig.SMTP.EnableSSL);
                smtpClient.Credentials = credential;
                smtpClient.Port = ipSpyConfig.SMTP.Port;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);

                logger.LogInformation("Mail sent to " + message.To[0].Address);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message + ": " + ex.StackTrace);
            }
        }
    }
}
