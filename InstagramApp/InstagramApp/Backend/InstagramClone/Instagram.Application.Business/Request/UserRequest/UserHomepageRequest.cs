using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Request.UserRequest
{
    public class UserHomepageResponse
    {
        public List<UserHomepageRequest> userHomepageRequests { get; set; }
    }
    public class UserHomepageRequest
    {
        public int Userid { get; set; }
        public string UserName { get; set; }
        public string? ProfilPicture { get; set; }
      //  public List<GetPostsRequest> Posts { get; set; }
        public string Posts { get; set; }
    }
}
