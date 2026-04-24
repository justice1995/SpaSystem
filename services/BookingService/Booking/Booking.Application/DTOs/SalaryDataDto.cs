using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTOs
{
    public class SalaryDataDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public EmployeeType Type { get; set; }

        public decimal BaseSalary { get; set; }
        public decimal TaxRate { get; set; }

        public decimal? Sale { get; set; }
        public decimal? CommissionRate { get; set; }

        public int? HoursWorked { get; set; }
        public decimal? HourRate { get; set; }
    }
}
