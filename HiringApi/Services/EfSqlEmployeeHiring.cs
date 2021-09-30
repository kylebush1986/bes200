using HiringApi.Data;
using HiringApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringApi.Services
{
    public class EfSqlEmployeeHiring : IHireEmployees
    {

        private readonly HiringDataContext _context;
        private readonly ILogRequests _requestLogger;

        public EfSqlEmployeeHiring(HiringDataContext context, ILogRequests requestLogger)
        {
            _context = context;
            _requestLogger = requestLogger;
        }

        public async Task<GetHiringResponse> HireAsync(PostHiringRequest request)
        {
            var hiringRequest = new HiringRequest
            {
                Department = request.Department,
                Name = request.Name,
                StartingSalary = request.StartingSalary,
                Status = HiringStatus.Pending,
                Id = Guid.NewGuid()
            };
            _context.HiringRequests.Add(hiringRequest);
            await _context.SaveChangesAsync();
            var response = new GetHiringResponse
            {
                Id = hiringRequest.Id,
                Department = hiringRequest.Department,
                Name = hiringRequest.Name,
                StartingSalary = hiringRequest.StartingSalary,
                Status = hiringRequest.Status
            };

            // hand this off for someone else to deal with...
            await _requestLogger.LogHiringRequestAsync(response);
            return response;
            
        }
    }
}
