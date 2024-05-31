using Instagram.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.IRepository.Password
{
    public interface IPasswordRepository
    {
        Task CreatePasswordAsync(UserPassword userPassword);

        Task<int> Userloggin(string userdetails,string password);
    }
}
