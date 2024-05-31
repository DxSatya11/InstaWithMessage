using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string? UserPosts { get; private set; }

        public int UserId { get; set; }
        public Users User { get; set; }


        public Posts Upload(string? userpost,int userId) 
        {
            this.UserPosts = userpost;
            this.UserId = userId;
            return this;
        }
    }
}
