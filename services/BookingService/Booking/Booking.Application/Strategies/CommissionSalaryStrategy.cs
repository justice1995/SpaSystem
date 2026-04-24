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
    public class CommissionSalaryStrategy : ISalaryStrategy
    {
        public EmployeeType Type => EmployeeType.Commission;

        public decimal Calculate(SalaryDataDto e)
        {
            var commission = e.Sale * e.CommissionRate;
            var tax = commission * e.TaxRate;

            return (commission - tax) ?? 0;
        }
    }
}
