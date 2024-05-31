using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.Models
{

    //User Profil
    public class Users
    {
        public int Id { get; set; } 
        public string UserName { get; private set; }
        public string GivenName { get; private set; }
        public string Email { get; private set; }
        public DateOnly DOB { get; private set;}
        public long ContactNo { get; private set; }
        public string? Country { get; private set; }
        public string? Bio { get; private set;}
        public string? ProfilPicture { get; private set;}

        public ICollection<Posts> Posts { get; set; }
        public UserPassword UserPassword { get; set; }
        public ICollection<Messaging> SentMessages { get; set; }
        public ICollection<Messaging> ReceivedMessages { get; set; }

        public Users CreatUser(string userName, string givenName, string email, DateOnly dob, long contactNo, string? country, string? bio, string? profilPicture)
        {
            this.UserName = userName;
            this.GivenName = givenName;
            this.Email = email;
            this.DOB = dob;
            this.ContactNo = contactNo;
            this.Country = country;
            this.Bio = bio;
            this.ProfilPicture = profilPicture;
            return this;
        }

    }
}
