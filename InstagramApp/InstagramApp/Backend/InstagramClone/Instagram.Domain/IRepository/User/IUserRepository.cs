using Instagram.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.IRepository
{
    public interface IUserRepository
    {
        Task CreateUSerAsync(Users users);
        Task<Users> GetUserByIdAsync(int id);

        Task<string> ProfilPicture(IFormFile file);
        Task<int> GetFollowingListCount(int id);
        Task<int> GetFollowersListCount(int id);
        Task<IList<Posts>> UserHomePageAsyncForAllFollowingUserData(int id);

        Task<IList<Users>> GetAllUser();

    }
}
