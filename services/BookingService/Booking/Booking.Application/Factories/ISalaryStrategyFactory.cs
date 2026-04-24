using BookingSystem.Application.Interfaces;
using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Factories
{
    public interface ISalaryStrategyFactory
    {
        ISalaryStrategy GetStrategy(EmployeeType employeeType);
    }
}
