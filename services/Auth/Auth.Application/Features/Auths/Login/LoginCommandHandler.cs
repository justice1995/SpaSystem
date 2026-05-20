using Auth.Application.Common;
using Auth.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Auths.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenStore _refreshTokenStore;
        private readonly IPasswordHasher _passwordHasher;
        public LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService, IRefreshTokenStore refreshTokenStore, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _refreshTokenStore = refreshTokenStore;
            _passwordHasher = passwordHasher;
        }
        public async Task<Result<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null) {
                return Result<LoginResponseDto>.Failure(new Error(ErrorType.Notfound, "Email not exists"));
            }

            if (!_passwordHasher.Verify(user.Password,request.Password))
            {
                return Result<LoginResponseDto>.Failure(new Error(ErrorType.BadRequest, "Invalid email or password"));
            }
            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = Guid.NewGuid().ToString();

            await _refreshTokenStore.SaveAsync(
            user.Id,
            refreshToken,
            TimeSpan.FromDays(7));
            return Result<LoginResponseDto>.Success(new LoginResponseDto(accessToken, refreshToken));
        }
    }
}
