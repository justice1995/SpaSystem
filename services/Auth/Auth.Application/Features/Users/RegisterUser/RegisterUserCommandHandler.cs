using Auth.Application.Common;
using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Users.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterUserCommandHandler(IUserRepository userRepository,
            IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.ExistsByEmailAsync(request.Email))
                return Result<Guid>.Failure(new Error(ErrorType.BadRequest, "Email already in use."));
            string passwordHash = _passwordHasher.Hash(request.Password);
            var user = new User(request.Name, request.Email, passwordHash);
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return Result<Guid>.Success(user.Id);
        }
    }
}
