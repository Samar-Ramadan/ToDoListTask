using Application;
using Application.Extentions;
using Application.Interfaces;
using Application.Models.TaskManagement;
using Domain.Entities;
using Domain.Enum;
using Infrastructures.Data;

namespace Infrastructures.Implementation.TaskManagement
{
    public class TaskService : Repository<TaskEntity>, ITaskService
    {
        public TaskService(AppDbContext context) : base(context)
        {
        }

        public async Task<GeneralOutPut<TaskModel>> GetBy(TaskSearchInput input,CancellationToken cancellationToken)
        {
            var listtaskEntities = await base.GetBy(x => (
                       input.Search != null ? x.Title.Contains(input.Search) || x.Description.Contains(input.Search) || x.Category.Contains(input.Search) : 1 == 1)
                    && (input.IsCompleted != null ? x.IsCompleted == input.IsCompleted : 1 == 1)
                    && (input.Priority == 0 ? x.Priority == Priority.Low : input.Priority == 1
                    ? x.Priority == Priority.Medium : input.Priority == 2 ? x.Priority == Priority.High : 1 == 1), cancellationToken);
            var listtaskModels = listtaskEntities.ToModelList();
            return Pagination<TaskModel>.PaginationList(listtaskModels.AsQueryable(), input);
        }

        public async Task<bool> Insert(TaskModel taskDto, CancellationToken cancellationToken)
        {
            taskDto.User = null;
            return await base.Add(taskDto.ToEntity(), cancellationToken);
        }
        //public string Update(TaskModel taskDto)
        //{
        //    var entity = GetById(taskDto.Id);

        //    taskDto.User = null;
        //    var map = _mapper.Map(taskDto, entity);
        //    Update(map);
        //    return "true";
        //}

        //public string Delete(int id)
        //{
        //    var entity = GetById(id);
        //    Delete(entity);
        //    return "true";
        //}

    }
}
