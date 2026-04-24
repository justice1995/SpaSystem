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
    public class FullTimeSalaryStrategy : ISalaryStrategy
    {
        public EmployeeType Type => EmployeeType.FullTime;

        public decimal Calculate(SalaryDataDto e)
        {
            var bonus = e.BaseSalary * 0.1m;
            var gross = e.BaseSalary + bonus;
            var tax = gross * e.TaxRate;

            return gross - tax;
        }
    }
}
