using Azure.Storage.Blobs;
using Instagram.Domain.IRepository.Post;
using Instagram.Domain.Models;
using Instagram.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Infrastructure.Repository.Post
{
    public class PostRepository : IPostRepository
    {
        private readonly InstagramDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public PostRepository(InstagramDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration; 
        }

        public async Task AddPostAsync(Posts post)
        {
           await _dbContext.Posts.AddAsync(post);
           await _dbContext.SaveChangesAsync();    
        }

        //Upload image in Blob
        public async Task<string> UploadInage(IFormFile file)
        {
            var containerName = "instagram-post";
            string connectionString = _configuration.GetConnectionString("AzureBlobStorage");

            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobName = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);

            var blobClient = containerClient.GetBlobClient(blobName);

            using (Stream stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, true);
            }

            return blobClient.Uri.ToString();
        }

    }
}
