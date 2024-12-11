using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var testRecords = await _testService.GetAllTestRecords();
            return Ok(testRecords);
        }


        [HttpPost]
        public async Task<bool> Create(TestDto testDto)
        {
            var result = await _testService.SaveTestRecord(testDto);
            return result;
        }

             
    }
}
