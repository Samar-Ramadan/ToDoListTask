using Application.Interfaces;
using Application.Models.TaskManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;
        public TasksController(ITaskService _taskService)
        {
            this.taskService = _taskService;
        }

        [HttpPost("GetBy")]
        [Authorize(Roles = "Owner , Guest")]
        public ResponesOutPut GetBy(TaskSearchInput input, CancellationToken cancellationToken)
        {

            var res = taskService.GetBy(input, cancellationToken);
            return  ResponesOutPut.Create(res, ResponseStatus.Success, "gfg");
        }


        [HttpPost("Insert")]
        [Authorize(Roles = "Owner")]
        public ResponesOutPut Insert(TaskModel taskDto, CancellationToken cancellationToken)
        {
            try
            {
                var res = taskService.Insert(taskDto, cancellationToken);
                return  ResponesOutPut.Create(res, ResponseStatus.Success, "Task added successfully");
            }
            catch (Exception ex)
            {
                return  ResponesOutPut.Create("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }
        }

        //[HttpPost("Update")]
        //[Authorize(Roles = "Owner")]
        //public ResponesOutPut Update(TaskModel taskDto, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var res = taskService.Update(taskDto, cancellationToken);
        //        return  ResponesOutPut.Create(res, ResponseStatus.Success, "Task Updated successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return  ResponesOutPut.Create("null", ResponseStatus.Error, $"Error: {ex.Message}");
        //    }
        //}

        //[HttpPost("Delete")]
        //[Authorize(Roles = "Owner")]
        //public ResponesOutPut Delete(int id, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var res = taskService.Delete(id, cancellationToken);
        //        return  ResponesOutPut.Create(res, ResponseStatus.Success, "Task Deleted successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return  ResponesOutPut.Create("null", ResponseStatus.Error, $"Error: {ex.Message}");
        //    }
        //}


    }
}
