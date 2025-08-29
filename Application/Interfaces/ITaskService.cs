
using Application.TaskManagment.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITaskService : IRepository<TaskEntity>
    {
        public Task<GeneralOutPut<TaskModel>> GetBy(TaskSearchInput input, CancellationToken cancellationToken);
        public Task<bool> Insert(TaskModel taskDto, CancellationToken cancellationToken);
        //public Task<bool> Update(TaskModel taskDto, CancellationToken cancellationToken);
        //public Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
