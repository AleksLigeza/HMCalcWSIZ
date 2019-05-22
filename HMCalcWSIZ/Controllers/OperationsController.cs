using HMCalcWSIZ.Core.DTO;
using HMCalcWSIZ.Infrastructure.Features.Queries.GetOperationsHistoryQuery;
using HMCalcWSIZ.Infrastructure.Features.Queries.GetSummaryQuery;
using HMCalcWSIZ.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HMCalcWSIZ.Infrastructure.Features.Commands.CreateOperationCommand;
using HMCalcWSIZ.Infrastructure.Features.Commands.DeleteOperationCommand;
using HMCalcWSIZ.Infrastructure.Features.Commands.UpdateOperationCommand;
using HMCalcWSIZ.Infrastructure.Features.Queries.GetCycleQuery;
using HMCalcWSIZ.Infrastructure.Features.Queries.GetOperationQuery;
using HMCalcWSIZ.Infrastructure.Migrations;
using Microsoft.AspNetCore.Authorization;

namespace HMCalcWSIZ.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/operations")]
    public class OperationsController : Controller
    {
        public readonly IBus bus;

        public OperationsController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet("history/{Skip}")]
        public async Task<IActionResult> GetHistory(int skip)
        {
            var query = new GetOperationsHistoryQuery { Skip = skip, Username = User.Identity.Name };
            var result = await bus.Run<GetOperationsHistoryQuery, List<OperationDTO>>(query);
            return Ok(result);
        }


        [HttpGet("cycles/{Skip}")]
        public async Task<IActionResult> GetCycleList(int skip)
        {
            var query = new GetCycleListQuery { Skip = skip, Username = User.Identity.Name };
            var result = await bus.Run<GetCycleListQuery, List<OperationDTO>>(query);
            return Ok(result);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistoryWithFilters([FromQuery] GetOperationsHistoryQuery query)
        {
            query.Username = User.Identity.Name;
            var result = await bus.Run<GetOperationsHistoryQuery, List<OperationDTO>>(query);
            return Ok(result);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> Summary()
        {
            var query = new GetSummaryQuery { Username = User.Identity.Name };
            var result = await bus.Run<GetSummaryQuery, GetSummaryQueryResult>(query);
            return Ok(result);
        }

        [HttpGet("operation/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var query = new GetOperationQuery { Username = User.Identity.Name, Id = id };
            var result = await bus.Run<GetOperationQuery, OperationDTO>(query);
            return Ok(result);
        }

        [HttpGet("cycle/{id}")]
        public async Task<IActionResult> GetCycle(int id)
        {
            var query = new GetCycleOperationsQuery { Username = User.Identity.Name, Id = id };
            var result = await bus.Run<GetCycleOperationsQuery, List<OperationDTO>>(query);
            return Ok(result);
        }

        [HttpDelete("operation/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOperationCommand { Username = User.Identity.Name, Id = id };
            await bus.Run(command);
            return Accepted();
        }

        [HttpPost("operation")]
        public async Task<IActionResult> Create([FromBody] CreateOperationCommand command)
        {
            command.Username = User.Identity.Name;
            await bus.Run(command);
            return Accepted();
        }

        [HttpPut("operation")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationCommand command)
        {
            command.Username = User.Identity.Name;
            await bus.Run(command);
            return Accepted();
        }
    }
}