using Instagram.Application.Business.Commands.Follow;
using Instagram.Application.Business.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers.Follow
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FollowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Following([FromBody] FollowingCommand followingCommand)
        {
            var following = await _mediator.Send(followingCommand);   
            return Ok(following);   

        }
    }
}
