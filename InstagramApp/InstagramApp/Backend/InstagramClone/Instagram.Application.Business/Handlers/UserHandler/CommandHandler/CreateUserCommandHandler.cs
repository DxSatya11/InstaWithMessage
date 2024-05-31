using Instagram.Application.Business.Commands.User;
using Instagram.Application.Business.Response.UserResponse;
using Instagram.Domain.IRepository;
using Instagram.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.UserHandler.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateUserResponse();

            var userPost = await _userRepository.ProfilPicture(request.ProfilPicture);

           

            DateOnly dateOnly = DateOnly.Parse(request.DOB);

            var createUSer = new Users().CreatUser(request.UserName, request.GivenName, request.Email, dateOnly, request.ContactNo, request.Country,
                                                   request.Bio, userPost);




            await _userRepository.CreateUSerAsync(createUSer);
            response.UsertId = createUSer.Id;   
            response.Message = "Welcom to Instagram";
            return response;

        }
    }
}
