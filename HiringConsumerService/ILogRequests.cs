using HiringConsumerService.Models;
using System.Threading.Tasks;

namespace HiringConsumerService
{
    public interface ILogRequests
    {
        Task DenyRequestAsync(HiringRequest request);
        Task ApproveRequestAsync(HiringRequest request);
    }
}