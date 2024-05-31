using Instagram.Application.Business.Commands.Post;
using Instagram.Application.Business.Response.PostResponse;
using Instagram.Domain.IRepository.Post;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;    
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("UploadPost/{id}")]
        public async Task<ActionResult<AddPostResponse>> UploadPost([FromRoute] int id, IFormFile post)
        {
            var uploadpost = await _mediator.Send(new AddPostCommand()
            {
                UserPosts = post,
                UserId = id

            });
            return Ok(uploadpost);  
        }
    }
}
