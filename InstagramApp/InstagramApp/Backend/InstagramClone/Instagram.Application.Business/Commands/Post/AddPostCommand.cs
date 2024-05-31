using Instagram.Application.Business.Response.PostResponse;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Commands.Post
{
    public class AddPostCommand : IRequest<AddPostResponse>
    {
        [Required(ErrorMessage = "Sorry you did not chose any file to upload")]
        public IFormFile? UserPosts { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
