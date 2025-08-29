using Application;
using Application.Extentions;
using Application.Interfaces;
using Application.TaskManagment.Models;
using Azure.Core;
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
            var listtaskEntities = await base.GetByAsync(x => (
                       input.Search != null ? x.Title.Contains(input.Search) || x.Description.Contains(input.Search) || x.Category.Contains(input.Search) : 1 == 1)
                    && (input.IsCompleted != null ? x.IsCompleted == input.IsCompleted : 1 == 1)
                    && (input.Priority == 0 ? x.Priority == input.Priority : 1 == 1), null, cancellationToken);
            var listtaskModels = listtaskEntities.ToModelList();
            return Pagination<TaskModel>.PaginationList(listtaskModels.AsQueryable(), input);
        }

        public async Task<bool> Insert(TaskModel taskDto, CancellationToken cancellationToken)
        {
            return await base.AddAsync(taskDto.ToEntity(), cancellationToken);
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
