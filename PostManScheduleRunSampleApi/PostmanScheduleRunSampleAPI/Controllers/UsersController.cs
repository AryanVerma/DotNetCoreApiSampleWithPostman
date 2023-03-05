using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostmanScheduleRunSampleAPI.Features.Users.Commands;
using PostmanScheduleRunSampleAPI.Features.Users.Queries;
using PostmanScheduleRunSampleAPI.Models;
using Swashbuckle.AspNetCore.Filters;

namespace PostmanScheduleRunSampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("fetchusers")]
        [Produces("application/json")]
        public async Task<IActionResult> FetchUsers()
        {
            var output = await _mediator.Send(new GetAllUsersQuery());
            return Ok(output);
        }
        [HttpGet("findUserbyId")]
        [Produces("application/json")]
        public async Task<IActionResult> FindUserById(int id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery() { Id = id }));
        }

        [HttpPost("createuser")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(UsersModel),typeof(UserPostExamples))]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            try
            {
                if (command != null)
                {
                    await _mediator.Send(command);
                    return Ok("Saved");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [HttpPost("updateuser")]
        [Produces("application/json")]

        [SwaggerRequestExample(typeof(UsersModel), typeof(UserPutExamples))]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(command);
        }

        [HttpDelete("deleteuser")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {

            await _mediator.Send(new DeleteUserCommand() { Id = id });
            return Ok();
        }
    }
}
