using BookingSystem.Application.DTOs;
using BookingSystem.Application.Interfaces;
using BookingSystem.Domain.Entities;
using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Strategies
{
    public class HourlySalaryStrategy : ISalaryStrategy
    {
        public EmployeeType Type => EmployeeType.Hourly;

        public decimal Calculate(SalaryDataDto e)
        {
            var gross = e.HoursWorked * e.HourRate;
            var tax = gross * e.TaxRate;

            return (gross - tax)??0;
        }
    }
}
