using Hackathon.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackhaton.WebAPI.Presentation.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            var result = await _service.EmployeeService.GetAllAsync(cancellationToken);
            return Ok(result); 
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateEmployeesAsync(CancellationToken cancellationToken)
        {
            var result = await _service.EmployeeService.GetAllAsync(cancellationToken);
            return Ok(result);
        }*/

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeesAsync(Guid guid)
        {
            var result = await _service.EmployeeService.GetByIdAsync(guid);
            return Ok(result);
        }
    }
}