using BookingSystem.Application.Interfaces;
using BookingSystem.Application.Strategies;
using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Factories
{
    public class SalaryStrategyFactory : ISalaryStrategyFactory
    {
        private readonly IEnumerable<ISalaryStrategy> _strategies;
        public SalaryStrategyFactory(IEnumerable<ISalaryStrategy> strategies)
        {
            _strategies = strategies;
        }
        public ISalaryStrategy GetStrategy(EmployeeType employeeType)
        {
            return _strategies.FirstOrDefault(x => x.Type == employeeType)??throw new Exception("Invalid type");
        }

    }
}
