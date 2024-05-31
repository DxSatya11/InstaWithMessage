using AutoMapper;
using Azure.Storage.Blobs;
using Instagram.Application.Business.Commands.Post;
using Instagram.Application.Business.Commands.User;
using Instagram.Application.Business.Message;
using Instagram.Application.Business.Query.User;
using Instagram.Application.Business.Request.UserRequest;
using Instagram.Application.Business.Response;
using Instagram.Application.Business.Response.UserResponse;
using Instagram.Domain.IRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;


namespace InstagramClone.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IHubContext<ChatHub> _hubContext;


        public UserController(IMediator mediator, IUserRepository userRepository, IHubContext<ChatHub> hubContext)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _hubContext = hubContext;
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateUserResponse>> CreateUser([FromForm] CreateUserCommand createUserCommand)
        {
            var user = await _mediator.Send(createUserCommand);
            return Ok(user);
        }


        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(GetUserRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUSerById([FromRoute]int userId)
        {
            try
            {
                var query = new GetUserByIdQuery { UserId = userId };
                var requestedUser = await _mediator.Send(query);
                if(requestedUser == null)
                {
                    return NotFound();  
                }
                return Ok(requestedUser); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFollowingUserDataAsync/{userId}")]
        [ProducesResponseType(typeof(UserHomepageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFollowingUserDataAsync([FromRoute] int userId)
        {
            try
            {
                var query = new GetUserHomePageDataQuery { UserId = userId };
                var requestedUser = await _mediator.Send(query);
                if (requestedUser == null)
                {
                    return NotFound();
                }

              //  return new UserHomepageResponse { userHomepageRequests = requestedUser}
                return Ok(requestedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllUserAsync/{userId}")]
        [ProducesResponseType(typeof(GetAllUserResponses), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUserAsync([FromRoute] int userId)
        {
            var student = await _mediator.Send(new GetAllUserQuery());
            return Ok(student);
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] MessageCommand commands)
        {

            await _mediator.Send(commands);
        
            return Ok(); 
        }

    }
}
