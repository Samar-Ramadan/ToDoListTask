using Application.Services.TaskManagement;
using Core.IGenericRepository;
using Core.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.TaskManagement
{
    public interface ITaskService : IRepository<Tasks>
    {
        public GeneralOutPut<TaskDto> GetBy(TaskSearchInput input);
        public string Insert (TaskDto taskDto);
        public string Update(TaskDto taskDto);
        public string Delete(int Id);
    }
}
