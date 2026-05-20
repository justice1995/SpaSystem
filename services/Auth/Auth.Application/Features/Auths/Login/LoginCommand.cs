using Auth.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Auths.Login
{
    public class LoginCommand:IRequest<Result<LoginResponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
