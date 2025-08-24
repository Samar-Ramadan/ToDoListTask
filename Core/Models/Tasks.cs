using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Tasks
    {
        [Required(ErrorMessage = "ToDoList_Tasks_Required_Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "ToDoList_Tasks_Required_Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ToDoList_Tasks_Required_Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ToDoList_Tasks_Required_IsCompleted")]
        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "ToDoList_Tasks_Required_Priority")]
        public Priority Priority { get; set; }

        [Required(ErrorMessage = "ToDoList_Tasks_Required_Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "ToDoList_Tasks_Required_CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "ToDoList_Tasks_Required_DueDate")]
        public DateTime? DueDate { get; set; }

        // علاقة مع المستخدم
        [Required(ErrorMessage = "ToDoList_Tasks_Required_UsersId")]
        public int UsersId { get; set; }
        public Users User { get; set; }
    }
}
