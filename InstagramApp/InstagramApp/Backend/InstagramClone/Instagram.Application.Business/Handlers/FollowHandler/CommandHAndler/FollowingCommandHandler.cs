using Instagram.Application.Business.Commands.Follow;
using Instagram.Application.Business.Response;
using Instagram.Domain.IRepository.FollowRelation;
using Instagram.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.FollowHandler.CommandHAndler
{
    public class FollowingCommandHandler : IRequestHandler<FollowingCommand, ApiResponse>
    {
        private readonly IFollowRepository _followRepository;
        public FollowingCommandHandler(IFollowRepository followRepository) 
        { 
            _followRepository = followRepository;   
        }

        public async Task<ApiResponse> Handle(FollowingCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse();

            var userFollowing = new Follow().Following(request.UsertId, request.FollowingUserId);
            int id = await _followRepository.CheckAlreadyFollowing(request.UsertId,request.FollowingUserId);
            if (id == 0)
            {
                response.Messsage = "Already Followed";
            }
            else if (id == request.UsertId)
            {
                response.Messsage = "You can't follow yourself";
            }
            else
            {
               await _followRepository.AddFollowing(userFollowing);
                response.Messsage ="You Followed";
            }
            return response;    

        }
    }
}
