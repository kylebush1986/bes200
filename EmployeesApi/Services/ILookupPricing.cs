using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public interface ILookupPricing
    {
        Task<int> GetPricingAsync();
    }
}
