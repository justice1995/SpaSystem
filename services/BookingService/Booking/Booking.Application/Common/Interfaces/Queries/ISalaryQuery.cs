using BookingSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Common.Interfaces.Queries
{
    public interface ISalaryQuery
    {
        public Task<List<SalaryDataDto>> GetListEmployeeAsync();
    }
}
