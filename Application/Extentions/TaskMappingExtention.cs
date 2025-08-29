
//using Application.Models.TaskManagement;
using Application.TaskManagment.Models;
using Domain.Entities;
using Domain.Enum;

namespace Application.Extentions
{
    public static class TaskMappingExtention
    {
        public static TaskModel ToModel(this TaskEntity task)
        {
            if (task == null) return null;

            return new TaskModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                Category = task.Category,
                CreatedAt = task.CreatedAt,
                DueDate = task.DueDate,
                UsersId = task.UsersId,
            };
        }

        public static List<TaskModel> ToModelList(this List<TaskEntity> tasks)
        {
            return tasks.Select(t => t.ToModel()).ToList();
        }

        public static TaskEntity ToEntity(this TaskModel task)
        {
            if (task == null) return null;

            return new TaskEntity
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Priority = task.Priority,
                Category = task.Category,
                CreatedAt = task.CreatedAt,
                DueDate = task.DueDate,
                UsersId = task.UsersId,

            };
        }
    }
}
