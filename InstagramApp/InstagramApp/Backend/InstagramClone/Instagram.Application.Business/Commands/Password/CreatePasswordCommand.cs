using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Generators;
using MediatR;
using Instagram.Application.Business.Response;
using System.Text.Json.Serialization;

namespace Instagram.Application.Business.Commands.Password
{
    public class CreatePasswordCommand : IRequest<ApiResponse>
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public  string Password { get; set; }


      
        public string Create(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentException("Password is required.");
            string hashedPassword = HashPassword(plainPassword);

            return hashedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }
    }
}
