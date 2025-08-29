using Application.TaskManagment.Models;
using Application.TaskManagment.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class MedaitorTaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MedaitorTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Posts/All")]
        public async Task<ActionResult<List<TaskModel>>> GetTasks(TaskSearchInput? input)
         => Ok(await _mediator.Send(new GetTasksQuery(input)));
    }
}
