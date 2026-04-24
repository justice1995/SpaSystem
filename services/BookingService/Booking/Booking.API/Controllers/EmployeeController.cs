using BookingSystem.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SalaryService _salaryService;
        public EmployeeController(SalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet("{id}/salary")]
        public async Task<IActionResult> GetSalary(Guid id)
        {
            try
            {
                var salary = await _salaryService.Calculate(id);
                return Ok(salary);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("salaries")]
        public async Task<IActionResult> GetAllSalaries()
        {
            var salaries = await _salaryService.GetAllSalary();
            return Ok(salaries);
        }
    }
}
