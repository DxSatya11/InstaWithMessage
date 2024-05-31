using Instagram.Application.Business.Commands.Password;
using Instagram.Application.Business.Response;
using Instagram.Domain.IRepository.Password;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.PasswordHandler.CommandHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse>
    {
        private readonly IPasswordRepository _passwordRepository;   

        public LoginCommandHandler(IPasswordRepository passwordRepository) 
        {
            _passwordRepository = passwordRepository;
        }
       

        public async Task<ApiResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginuserId = new ApiResponse();
            var userId = await _passwordRepository.Userloggin(request.UserData, request.Password);
            loginuserId.Id = userId;
            return loginuserId;
        }
    }
}
