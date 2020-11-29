using System.Threading.Tasks;

namespace AspNetCoreMini.Core
{
    public delegate Task RequestDelegate(HttpContext context);
}