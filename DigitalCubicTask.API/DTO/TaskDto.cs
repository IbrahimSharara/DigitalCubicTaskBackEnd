using DigitalCubicTask.API.Entities;

namespace DigitalCubicTask.API.DTO
{
    public class TaskDto
    {
        public Int64 Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Int64 assigned_user_id { get; set; }
        public string assigned_user_Name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isCompleted { get; set; }
       // public virtual User assigned_user_nav { get; set; }
    }
}
