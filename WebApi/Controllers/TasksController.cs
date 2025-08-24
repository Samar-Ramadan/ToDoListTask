using Aplication.Services.TaskManagement;
using Application.Services.TaskManagement;
using Application.Services.UserManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ResponesOutPut GetBy(TaskSearchInput input)
        {

            var res = taskService.GetBy(input);
            return new ResponesOutPut(res, ResponseStatus.Success, "gfg");
        }


        [HttpPost("Insert")]
        [Authorize(Roles = "Owner")]
        public ResponesOutPut Insert(TaskDto taskDto)
        {
            try
            {
                var res = taskService.Insert(taskDto);
                return new ResponesOutPut(res, ResponseStatus.Success, "Task added successfully");
            }
            catch (Exception ex)
            {
                return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }
        }

        [HttpPost("Update")]
        [Authorize(Roles = "Owner")]
        public ResponesOutPut Update(TaskDto taskDto)
        {
            try
            {
                var res = taskService.Update(taskDto);
                return new ResponesOutPut(res, ResponseStatus.Success, "Task Updated successfully");
            }
            catch (Exception ex)
            {
                return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "Owner")]
        public ResponesOutPut Delete(int id)
        {
            try
            {
                var res = taskService.Delete(id);
                return new ResponesOutPut(res, ResponseStatus.Success, "Task Deleted successfully");
            }
            catch (Exception ex)
            {
                return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }
        }


    }
}
