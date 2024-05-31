using Instagram.Application.Business.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Commands.Follow
{
    public class FollowingCommand : IRequest<ApiResponse>
    {
        public int UsertId { get; set; }    
        public int FollowingUserId {  get; set; }   
    }
}
