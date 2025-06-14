using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalCubicTask.API.Entities
{
    public class TaskItem
    {
        [Key]
        public Int64 Id { get; set; }
        public string title { get; set; }
        public string description { get;  set; }
        [ForeignKey("assigned_user_nav")]
        public Int64 assigned_user_id { get;  set; }
        public DateTime startDate { get;  set; }
        public DateTime endDate { get;  set; }
        public bool isCompleted { get;  set; }
        public virtual User assigned_user_nav { get;  set; }
    }
}
