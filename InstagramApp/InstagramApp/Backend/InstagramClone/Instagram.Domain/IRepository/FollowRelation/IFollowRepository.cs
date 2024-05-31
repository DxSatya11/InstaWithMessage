using Instagram.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.IRepository.FollowRelation
{
    public interface IFollowRepository
    {
        Task AddFollowing(Follow follow);
        Task<int> CheckAlreadyFollowing(int userid,int followingid);
    }
}
