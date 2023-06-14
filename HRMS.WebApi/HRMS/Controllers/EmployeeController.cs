using HRMS.Domain.Entities;
using HRMS.Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost("LeaveApplication")]
        public async Task<IActionResult> LeaveApplication(Leave leave)
        {
            int entry = await _employeeRepository.LeaveApplication(leave);
            return Ok(entry);
        }
    }
}
