using Alba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApiIntegrationTests
{
    public class DemoFixture : IDisposable
    {
        public readonly IAlbaHost AlbaHost = EmployeesApi.Program.CreateHostBuilder(Array.Empty<string>()).StartAlba();
        public void Dispose()
        {
            AlbaHost?.Dispose();
        }
    }
}
