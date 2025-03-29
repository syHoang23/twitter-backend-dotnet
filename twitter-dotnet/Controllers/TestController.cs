using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    public class TestController : BaseApiController
    {

        public TestController(IConfiguration config)
        {
        }

        [HttpGet]
        public string Test()
        {
            return "Hello World!";
        }

    }
}