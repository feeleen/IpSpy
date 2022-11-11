namespace IpSpy.Services
{
    public interface IIpSpyService
    {
        Task<string> GetIPAsync();
    }
}