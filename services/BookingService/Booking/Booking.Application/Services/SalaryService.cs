using BookingSystem.Application.Common.Interfaces.Queries;
using BookingSystem.Application.Common.Interfaces.Repositories;
using BookingSystem.Application.DTOs;
using BookingSystem.Application.Factories;
using BookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookingSystem.Application.Services
{
    public class SalaryService
    {
        private  readonly ISalaryStrategyFactory _salaryStrategyFactory;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISalaryQuery _salaryQuery;
        public SalaryService(ISalaryStrategyFactory salaryStrategyFactory, IEmployeeRepository employeeRepository, ISalaryQuery salaryQuery)
        {
            _salaryStrategyFactory = salaryStrategyFactory;
            _employeeRepository= employeeRepository;
            _salaryQuery = salaryQuery;
        }

        public async Task<decimal> Calculate(Guid employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId)
                     ?? throw new Exception("Employee not found");
            var strategy = _salaryStrategyFactory.GetStrategy(employee.EmployeeType);
            return 0;// strategy.Calculate(employee);
        }
        public async Task<List<SalaryReponseDto>> GetAllSalary()
        {
            var employees = await _salaryQuery.GetListEmployeeAsync();
            List<SalaryReponseDto> result = new List<SalaryReponseDto>();

            // Get List sale 
            foreach (var item in employees)
            {
                var strategy = _salaryStrategyFactory.GetStrategy(item.Type);

                //Truyen sale vao de tinh commission
                var salary = strategy.Calculate(item);

                //luu snapshot chot ky luong nay

                result.Add(new SalaryReponseDto
                {
                    Id = item.Id,
                    EmployeeName = item.Name,
                    TotalSalary = salary
                });
            }

            return result;
        }
    }
}
