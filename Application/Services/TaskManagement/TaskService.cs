using Aplication.Services.TaskManagement;
using AutoMapper;
using Core.Enum;
using Core.Models;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.Data.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TaskManagement
{
    public class TaskService : Repository<Tasks>, ITaskService
    {
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;
        public TaskService(AppDbContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _config = new MapperConfiguration(cfg => { cfg.CreateMap<Tasks, TaskDto>().ReverseMap(); });
            _mapper = _config.CreateMapper();
        }

        public GeneralOutPut<TaskDto> GetBy(TaskSearchInput input)

        {
            IQueryable<TaskDto> res = _mapper.ProjectTo<TaskDto>(base.GetBy(x => ((
                       (input.Search != null ? x.Title.Contains(input.Search) || x.Description.Contains(input.Search) || x.Category.Contains(input.Search) : 1==1))
                    && (input.IsCompleted != null ?  x.IsCompleted == input.IsCompleted : 1 == 1)
                    && (input.Priority == 0 ?  x.Priority == Priority.Low : input.Priority == 1 
                    ? x.Priority == Priority.Medium : input.Priority == 2 ? x.Priority == Priority.High : 1 == 1))));
            return Pagination<TaskDto>.PaginationList(res.AsQueryable(), input);
        }

        public string Insert(TaskDto taskDto)
        {
            taskDto.User = null;
            var map = _mapper.Map<Tasks>(taskDto);
            base.Add(map);
            return "true";
        }
        public string Update(TaskDto taskDto)
        {
            var entity = base.GetById(taskDto.Id);

            taskDto.User = null;
            var map = _mapper.Map<TaskDto, Tasks>(taskDto, entity);
            base.Update(map);
            return "true";
        }

        public string Delete(int id)
        {
            var entity = base.GetById(id);
            base.Delete(entity);
            return "true";
        }

    }
}
