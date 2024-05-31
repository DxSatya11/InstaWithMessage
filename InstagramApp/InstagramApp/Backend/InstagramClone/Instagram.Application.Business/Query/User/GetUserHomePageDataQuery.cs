using Instagram.Application.Business.Request.UserRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Query.User
{
    public class GetUserHomePageDataQuery : IRequest<UserHomepageResponse>
    {
        public int UserId { get; set; }
    }
}
