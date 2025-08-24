using Core.Enum;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TaskManagement
{
    public class TaskDto
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
        public Users? User { get; set; }

    }
}
