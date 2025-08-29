
using Application.Extentions;
using Application.Interfaces;
using Application.TaskManagment.Models;
using Domain.Entities;
using Domain.Enum;
using MediatR;

namespace Application.TaskManagment.Queries
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, GeneralOutPut<TaskModel>>
    {
        private readonly IRepository<TaskEntity> _repo;
        public GetTasksQueryHandler(IRepository<TaskEntity> repo) => _repo = repo;


        public async Task<GeneralOutPut<TaskModel>> Handle(GetTasksQuery request, CancellationToken ct)
        {
            var listtaskEntities = await _repo.GetByAsync(x => (
                       request.input.Search != null ? x.Title.Contains(request.input.Search) || x.Description.Contains(request.input.Search) || x.Category.Contains(request.input.Search) : 1 == 1)
                    && (request.input.IsCompleted != null ? x.IsCompleted == request.input.IsCompleted : 1 == 1)
                    && (request.input.Priority == 0 ? x.Priority == request.input.Priority: 1 == 1), x=>x.Users, ct);
            var listtaskModels = listtaskEntities.ToModelList();
            return Pagination<TaskModel>.PaginationList(listtaskModels.AsQueryable(),request.input);

        }
    }
}
