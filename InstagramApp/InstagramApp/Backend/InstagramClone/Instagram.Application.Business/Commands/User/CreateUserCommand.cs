using Azure.Core;
using Instagram.Application.Business.Response.UserResponse;
using Instagram.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Commands.User
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Given name is required")]
        public string GivenName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Date of birth is required")]
        public string DOB { get; set; }


        [Required(ErrorMessage = "Contact number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid contact number")]
        public long ContactNo { get; set; }


        public string? Country { get; set; }
        [MaxLength(500, ErrorMessage = "Bio cannot exceed 500 characters")]
        public string? Bio { get; set; }



        [Required(ErrorMessage = "Invalid URL format for profile picture")]
        public IFormFile? ProfilPicture { get; set; }


    }
}
