using HiringApi.Models;
using System.Threading.Tasks;

namespace HiringApi.Services
{
    public interface IHireEmployees
    {
        Task<GetHiringResponse> HireAsync(PostHiringRequest request);
    }
}