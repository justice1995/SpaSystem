using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Enums
{
    public enum ErrorType
    {
        [Description("NOT_FOUND")]
        Notfound,
        [Description("UNAUTHORIZED")]
        Unauthorized,
        [Description("FORBIDDEN")]
        Forbidden,
        [Description("BAD_REQUEST")]
        BadRequest,
        [Description("INTERNAL_SERVER_ERROR")]
        InternalServerError
    }
}
