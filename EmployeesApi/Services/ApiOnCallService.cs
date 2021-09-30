using EmployeesApi.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class ApiOnCallService
    {
        private readonly HttpClient _client;
        private readonly ILogger<ApiOnCallService> _logger;
        public ApiOnCallService(HttpClient client, ILogger<ApiOnCallService> logger)
        {
            _client = client;
            _logger = logger;
            _logger.LogInformation("Using base address of :" + _client.BaseAddress.ToString());
        }

        public async Task<StandbyDeveloperInfo> GetDeveloperInfoAsync()
        {

            var response = await _client.GetAsync("/oncall");
            var content = await response.Content.ReadAsStringAsync();

            var developerInfo = JsonSerializer.Deserialize<StandbyDeveloperInfo>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return developerInfo;

        }
    }
}
