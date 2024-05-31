using Azure.Storage.Blobs;
using Instagram.Domain.IRepository;
using Instagram.Domain.Models;
using Instagram.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Infrastructure.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly InstagramDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public UserRepository(InstagramDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration; 
        }

        public async Task CreateUSerAsync(Users users)
        {
            await _dbContext.Users.AddAsync(users);
            await _dbContext.SaveChangesAsync();
        }

       

        public async Task<Users> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.Where(x => x.Id == id).Include(x => x.Posts).FirstOrDefaultAsync();

            if(user != null)
            {
                user.Posts = user.Posts.OrderByDescending(x => x.Id).ToList();   
            }
            return user;
        }

        public async Task<string> ProfilPicture(IFormFile file)
        {

            var special = Guid.NewGuid().ToString();
            var containerName = "instagram-profilpicture";
            string connectionString = _configuration.GetConnectionString("AzureBlobStorage");

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobName = special + "-" + file.FileName;
            var blobClient = containerClient.GetBlobClient(blobName);

            using (Stream stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            return blobClient.Uri.ToString();
        }

        public async  Task<int> GetFollowingListCount(int id)
        {
            int followinglist = _dbContext.Follows.Where(x => x.UserId == id).Select(Fi => Fi.FollowingUserId).Count();
            return followinglist;   
        }

        public async Task<int> GetFollowersListCount(int id)
        {
            int followerCount = _dbContext.Follows.Count(x => x.FollowingUserId == id);
            return followerCount;
        }

        public async Task<IList<Users>> UserHomePageAsync(int id)
        {
           var followingIds = await _dbContext.Follows.Where(x => x.UserId == id).Select(x => x.FollowingUserId).ToListAsync();
           followingIds.Add(id);

          var followinguiserData = await _dbContext.Users.Where(user => followingIds.Contains(user.Id)).Include(x => x.Posts).ToListAsync();  
          return followinguiserData;  
        }

        public async Task<IList<Posts>> UserHomePageAsyncForAllFollowingUserData(int id)
        {
            var followingIds = await _dbContext.Follows
                .Where(x => x.UserId == id)
                .Select(x => x.FollowingUserId)
                .ToListAsync();

            followingIds.Add(id);

            var followingUserData = await _dbContext.Posts
                .Where(user => followingIds.Contains(user.UserId))
                .Include(x => x.User)
                .OrderByDescending(user => user.Id)
                .ToListAsync();

            return followingUserData;
        }

        public async Task<IList<Users>> GetAllUser()
        {
           var userlist = await _dbContext.Users.ToListAsync();   
            return userlist;    
        }
    }
}
