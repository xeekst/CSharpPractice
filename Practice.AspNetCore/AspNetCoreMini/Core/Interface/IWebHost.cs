using System.Threading.Tasks;

namespace AspNetCoreMini.Core.Interface
{
    public interface IWebHost
    {
        Task StartAsync();
    }
}