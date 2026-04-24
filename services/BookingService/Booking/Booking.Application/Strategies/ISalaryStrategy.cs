using BookingSystem.Application.DTOs;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Interfaces
{
    public interface ISalaryStrategy
    {
        EmployeeType Type { get; }
        decimal Calculate(SalaryDataDto employee);
    }
}
