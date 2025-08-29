using Application.Models.UserManagement;
using Domain.Enum;

namespace Application.TaskManagment.Models
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
        public int UsersId { get; set; }
        public UserModel Users { get; set; }
    }
}
