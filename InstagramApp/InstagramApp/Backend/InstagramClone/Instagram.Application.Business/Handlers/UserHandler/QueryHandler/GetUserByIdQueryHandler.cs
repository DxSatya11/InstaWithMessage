using Instagram.Application.Business.Query.User;
using Instagram.Application.Business.Request.UserRequest;
using Instagram.Domain.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.UserHandler.QueryHandler
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserRequest>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserRequest> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            int followingList = await _userRepository.GetFollowingListCount(request.UserId);
            int followersList = await _userRepository.GetFollowersListCount(request.UserId);  

            var requestedUser = new GetUserRequest
            {
                Userid = request.UserId,
                UserName = user.UserName,
                GivenName = user.GivenName,
                Bio = user.Bio,
                ProfilPicture = user.ProfilPicture,
                FollowersList = followersList,
                FollowingList = followingList,    
                Posts = user.Posts.Select(p => new GetPostsRequest { UserPosts = p.UserPosts}).ToList()

            };

            return requestedUser;
        }
    }
}
