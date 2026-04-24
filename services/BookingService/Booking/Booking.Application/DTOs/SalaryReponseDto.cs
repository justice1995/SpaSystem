using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTOs
{
    public class SalaryReponseDto
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
