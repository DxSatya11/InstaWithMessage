using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.Models
{
    public class UserPassword
    {
        [Key]
        public int Id { get; set; }
        public string Password { get;private set; }

        public int UserId {  get; private set; }    
        public Users  Users { get; set; }

        public UserPassword Create(int userId, string password)
        {
            this.UserId = userId;
            this.Password = password;
            return this;
        }

    }
}
