using IpSpy;
using IpSpy.Services;

IConfiguration config = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
	.AddEnvironmentVariables()
	.Build();

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "IpSpy Service";
    })
    .ConfigureServices(services =>
    {
		services.Configure<IpSpyConfig>(config.GetSection("IpSpy"));
		services.AddHttpClient<IIpSpyService, IpSpyService>();
		services.AddHttpClient<IMailService, MailService>();
		//services.AddSingleton<MailService>();
		services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
