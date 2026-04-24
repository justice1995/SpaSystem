using BookingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Common
{
    public class Error
    {
        public ErrorType ErrorType { get; }
        public string Detail { get; }

        public Error(ErrorType errorType, string detail)
        {
            ErrorType = errorType;
            Detail = detail;
        }
    }
}
