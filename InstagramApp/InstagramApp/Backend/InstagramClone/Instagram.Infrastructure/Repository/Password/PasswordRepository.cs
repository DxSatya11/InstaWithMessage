using Instagram.Domain.IRepository.Password;
using Instagram.Domain.Models;
using Instagram.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Instagram.Infrastructure.Repository.Password
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly InstagramDbContext _dbContext;
        public PasswordRepository(InstagramDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreatePasswordAsync(UserPassword userPassword)
        {
           await _dbContext.UserPassword.AddAsync(userPassword);    
           await _dbContext.SaveChangesAsync();    
        }

        public async Task<int> Userloggin(string userdetails, string password)
        {
            var user = await _dbContext.Users
                .Where(u => u.UserName == userdetails || u.Email == userdetails)
                .Include(up => up.UserPassword) 
                .FirstOrDefaultAsync();

            // Check if the user exists and Verify Password
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.UserPassword.Password))
                return user.Id;
            else return 0;  
            
        }

    }
}
