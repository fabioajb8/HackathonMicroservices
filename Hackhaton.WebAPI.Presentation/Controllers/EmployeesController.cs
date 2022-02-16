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

        public async Task<IActionResult> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            var result = await _service.EmployeeService.GetAllAsync(cancellationToken);
            return Ok(result); 
        }
    }
}