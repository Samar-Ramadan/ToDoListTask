using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserManagement
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [Required(ErrorMessage = "ToDoList_Users_Required_Password")]
        [StringLength(10)]
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
