using Instagram.Application.Business.Commands.Post;
using Instagram.Application.Business.Commands.User;
using Instagram.Application.Business.Response.PostResponse;
using Instagram.Application.Business.Response.UserResponse;
using Instagram.Domain.IRepository.Post;
using Instagram.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.Business.Handlers.PostHandler.CommandHAndler
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, AddPostResponse>
    {
        private readonly IPostRepository _postRepository;
        public AddPostCommandHandler(IPostRepository postRepository) => _postRepository = postRepository;

        public async Task<AddPostResponse> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var response = new AddPostResponse();
            var userPost = await _postRepository.UploadInage(request.UserPosts);
            var uploadPost = new Posts().Upload(userPost, request.UserId);
            await _postRepository.AddPostAsync(uploadPost);
            response.Message = "Upload Successfully";
            return response;
        }
    }
}
