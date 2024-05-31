using Instagram.Domain.IRepository.FollowRelation;
using Instagram.Domain.Models;
using Instagram.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Infrastructure.Repository.FollowRelation
{
    public class FollowRepository : IFollowRepository
    {
        private readonly InstagramDbContext _dbContext;
        public FollowRepository(InstagramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFollowing(Follow follow)
        {
            await _dbContext.Follows.AddAsync(follow);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CheckAlreadyFollowing(int userid, int followingid)
        {
           
            var isFollowing = await _dbContext.Follows
                   .AnyAsync(x => x.UserId == userid && x.FollowingUserId == followingid);

            return isFollowing ? 0 : followingid;
        }
    }
}
