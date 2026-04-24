using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Old { get; private set; }
        public string Address { get; private set; }
        public decimal TaxRate { get; private set; }

        public EmployeeType EmployeeType { get; private set; }

        public decimal BaseSalary { get; private set; }

        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; private set; }

        public decimal Sale { get; private set; }
        public decimal CommissionRate { get; private set; }

        // 👉 EF Core cần constructor rỗng
        private Employee() { }

        public Employee(string name, int old, string address, EmployeeType employeeType, decimal baseSalary, decimal taxRate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Old = old;
            Address = address;
            EmployeeType = employeeType;
            BaseSalary = baseSalary;
            TaxRate = taxRate;
        }

        // 👉 Set commission data
        public void SetCommission(decimal sales, decimal rate)
        {
            if (EmployeeType != EmployeeType.Commission)
                throw new InvalidOperationException("Not commission employee");

            Sale = sales;
            CommissionRate = rate;
        }

        // 👉 Set hourly data
        public void SetHourly(int hours, decimal rate)
        {
            if (EmployeeType != EmployeeType.Hourly)
                throw new InvalidOperationException("Not hourly employee");

            HoursWorked = hours;
            HourlyRate = rate;
        }

    }
}
