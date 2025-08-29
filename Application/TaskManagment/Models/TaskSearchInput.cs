namespace Application.TaskManagment.Models
{
    public class TaskSearchInput : PageingInfo
    {
        public bool? IsCompleted { get; set; }
        public int? Priority { get; set; }
        //public DateTime? FromCreatedAt { get; set; }
        //public DateOnly? ToCreatedAt { get; set; }
        //public DateOnly? FromDueDate { get; set; }
        //public DateOnly? ToDueDate { get; set; }
    }
}
