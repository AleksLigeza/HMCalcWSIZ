using System.Collections.Generic;
using HMCalcWSIZ.Core.DTO;
using HMCalcWSIZ.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HMCalcWSIZ.Infrastructure.Features.Commands.RegisterUserCommand;
using HMCalcWSIZ.Infrastructure.Features.Queries.GetUsersQuery;

namespace HMCalcWSIZ.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBus bus;

        public UsersController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await bus.Run<GetUsersQuery, List<UserDto>>(new GetUsersQuery());
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            await bus.Run<RegisterUserCommand>(command);
            return Accepted();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Accepted();
        }

    }
}
