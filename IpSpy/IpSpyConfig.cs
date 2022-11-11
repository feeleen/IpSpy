using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpSpy
{
    public class IpSpyConfig
	{
		public string IPProviderHost { get; set; }
		public int CheckInterval { get; set; }
		public SMTP SMTP { get; set; }
		public Email Email { get; set; }
	}

	public class Email
	{
		public string To { get; set; }
		public string Subject { get; set; }
		public string BodyFormat { get; set; }
	}

	public class SMTP
	{
		public string Login { get; set; }
		public string Password { get; set; }
		public int Port { get; set; }
		public string Host { get; set; }
		public string EnableSSL { get; set; }
	}
}
