using System.Threading.Tasks;

namespace AspNetCoreMini.Core.Interface
{
    public interface IServer
    {
        Task StartAsync(RequestDelegate handler);
    }
}