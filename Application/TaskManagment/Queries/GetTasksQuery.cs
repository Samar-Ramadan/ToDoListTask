using Application.TaskManagment.Models;
using MediatR;
namespace Application.TaskManagment.Queries
{

    public record GetTasksQuery(TaskSearchInput input) : IRequest<GeneralOutPut<TaskModel>>;
}
