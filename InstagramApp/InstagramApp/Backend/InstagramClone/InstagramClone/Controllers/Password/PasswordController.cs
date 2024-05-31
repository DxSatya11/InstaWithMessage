using Instagram.Application.Business.Commands.Password;
using Instagram.Application.Business.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Controllers.Password
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        public IMediator _mediator;
        public PasswordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreatePassWordAsync/{id}")]
        public async Task<ActionResult<ApiResponse>> CreatePassWordAsync([FromRoute]int id,[FromBody] CreatePasswordCommand createPasswordCommand)
        {
           
            var passwordset =await _mediator.Send(new CreatePasswordCommand
            {
                UserId = id,
                Password = createPasswordCommand.Password 
            });  
            return Ok(passwordset);
        }

        [HttpGet("UserLoginAsync")]
        public async Task<ActionResult<ApiResponse>> UserLoginAsync([FromQuery] LoginCommand loginCommand)
        {
            var userId = await _mediator.Send(loginCommand);
            return Ok(userId);  
        }
    }
}
