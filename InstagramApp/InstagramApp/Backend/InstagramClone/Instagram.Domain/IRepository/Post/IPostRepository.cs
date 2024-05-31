using Instagram.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.IRepository.Post
{
    public interface IPostRepository
    {
        Task AddPostAsync(Posts post);

        Task<string> UploadInage(IFormFile file);
    }
}
