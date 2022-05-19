using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CQRS_using_MediatR.Features.User;
using Microsoft.AspNetCore.Cors;

namespace CQRS_using_MediatR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetUserById([Required] int id)
        {
            var response = await _mediator.Send(new GetUserRequestQuery { UserId = id });
            return Ok(response);
        }

        [HttpPost("/")]
        public async Task<IActionResult> AddUser(string userName, bool isDeleted) 
        {
            var response = await _mediator.Send(new AddUserCommand(userName, isDeleted));
            return Ok();
        }
    }
}
