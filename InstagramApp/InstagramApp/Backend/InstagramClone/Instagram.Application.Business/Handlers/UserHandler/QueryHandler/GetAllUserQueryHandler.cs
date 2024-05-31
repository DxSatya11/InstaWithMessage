using Instagram.Application.Business.Query.User;
using Instagram.Application.Business.Request.UserRequest;
using Instagram.Application.Business.Response;
using Instagram.Domain.IRepository;
using Instagram.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.UserHandler.QueryHandler
{
    public class GetAllUSerQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserResponses>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUSerQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetAllUserResponses> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var userlist = await _userRepository.GetAllUser();

            var users = new List<GetAllUserResponse>();
            foreach (var user in userlist)
            {
                var userRequest = new GetAllUserResponse
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    ProfilPicture = user.ProfilPicture
                };
                users.Add(userRequest);
            }
            return new GetAllUserResponses { GetAllUserResponse = users };
        }

    }
}
