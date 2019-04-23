using System.Collections.Generic;
using HMCalcWSIZ.Core.DTO;
using HMCalcWSIZ.Infrastructure.Features.GetSomethingQuery;
using HMCalcWSIZ.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var response = await bus.Run<GetUsersQuery, List<UserDto>> (new GetUsersQuery());
            return Ok(response);
        }
    }
}
