using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserEntity
    {
        [Required(ErrorMessage = "ToDoList_Users_Required_Id")]
        [Range(1, 9999)]
        public int Id { get; set; }

        [Required(ErrorMessage = "ToDoList_Users_Required_Username")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "ToDoList_Users_Required_Password")]
        [StringLength(10)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ToDoList_Users_Required_Role")]
        [Range(1, 2)]
        public UserRole Role { get; set; }
    }
}
