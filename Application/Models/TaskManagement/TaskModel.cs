using Domain.Entities;

namespace Application.Models.TaskManagement
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }

        // علاقة مع المستخدم
        public int UsersId { get; set; }
        public UserEntity? User { get; set; }

    }
}
