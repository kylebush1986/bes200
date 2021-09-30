using HiringApi.Models;
using System.Threading.Tasks;

namespace HiringApi.Services
{
    public interface ILogRequests
    {
        Task LogHiringRequestAsync(GetHiringResponse response);
    }
}