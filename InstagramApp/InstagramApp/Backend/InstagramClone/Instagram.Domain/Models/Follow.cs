using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.Models
{
    public class Follow
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId {  get; set; }
        public virtual Users User { get; set; }
        [ForeignKey("FollowingId")]
        public int? FollowingUserId {  get; set; }
        public virtual Users FollowingUser { get; set; }


        public virtual ICollection<Messaging> MessagesSentByFollower { get; set; }

        public Follow Following(int userId,int followinguserid)
        {
            this.UserId = userId;
            this.FollowingUserId = followinguserid; 
            return this;
        }
    }
}
