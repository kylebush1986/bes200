using Alba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApiIntegrationTests
{
    public class DemoResourceTests : IClassFixture<DemoFixture>
    {
        private readonly IAlbaHost _host;
        public DemoResourceTests(DemoFixture app)
        {
            _host = app.AlbaHost;
        }

        [Fact]
       public async Task ShouldBeAbleToGetProducts()
        {
            await _host.Scenario(_ =>
            {
                _.Get.Url("/products/13");
                _.ContentShouldBe("Here is product 13");
                _.StatusCodeShouldBeOk();
                _.Header("Content-Type").SingleValueShouldEqual("text/plain; charset=utf-8");
            });
        }
    }
}
