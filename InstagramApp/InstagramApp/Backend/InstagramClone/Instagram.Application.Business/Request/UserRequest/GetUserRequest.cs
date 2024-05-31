using Instagram.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Request.UserRequest
{
    public class GetUserRequest
    {
        public int Userid { get; set; } 
        public string UserName { get; set; }
        public string GivenName { get; set; }
        public string? Bio { get; set; }
        public string? ProfilPicture { get; set; }

        public int? FollowingList { get; set; }
        public int? FollowersList { get; set; }

        public ICollection<GetPostsRequest> Posts { get; set; }
    }

}
