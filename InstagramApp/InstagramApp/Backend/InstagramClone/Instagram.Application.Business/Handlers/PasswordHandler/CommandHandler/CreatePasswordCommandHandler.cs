using Instagram.Application.Business.Commands.Password;
using Instagram.Application.Business.Response;
using Instagram.Domain.IRepository.Password;
using Instagram.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.PasswordHandler.CommandHandler
{
    public class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, ApiResponse>
    {
        private IPasswordRepository _passwordRepository;
        public CreatePasswordCommandHandler(IPasswordRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;   
        }
        public async Task<ApiResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse();
            string hashpassword =  new  CreatePasswordCommand().Create(request.Password);   

            var setpassword = new UserPassword().Create(request.UserId, hashpassword);
            await _passwordRepository.CreatePasswordAsync(setpassword);
            response.Messsage = "You created password successfully please remember!";
            return response;
        }
    }
}
