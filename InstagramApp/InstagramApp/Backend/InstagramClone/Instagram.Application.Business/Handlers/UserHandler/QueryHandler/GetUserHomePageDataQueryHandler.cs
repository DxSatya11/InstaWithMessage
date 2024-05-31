using Instagram.Application.Business.Query.User;
using Instagram.Application.Business.Request.UserRequest;
using Instagram.Domain.IRepository;
using Instagram.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.UserHandler.QueryHandler
{
    public class GetUserHomePageDataQueryHandler : IRequestHandler<GetUserHomePageDataQuery, UserHomepageResponse>
    {
        private readonly IUserRepository _userRepository;
        public GetUserHomePageDataQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserHomepageResponse> Handle(GetUserHomePageDataQuery request, CancellationToken cancellationToken)
        {
            var requestedUser = new List<UserHomepageRequest>();
            var followinguserdata = await _userRepository.UserHomePageAsyncForAllFollowingUserData(request.UserId);

            foreach (var user in followinguserdata)
            {
            
                var userRequest = new UserHomepageRequest
                {
                    Userid = user.UserId,
                    UserName = user.User.UserName,
                    ProfilPicture = user.User.ProfilPicture,
                    Posts = user.UserPosts
                };

                requestedUser.Add(userRequest);
            }

            return new UserHomepageResponse { userHomepageRequests = requestedUser };   
        }


    }
}
