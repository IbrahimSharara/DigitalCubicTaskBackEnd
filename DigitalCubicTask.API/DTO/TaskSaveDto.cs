namespace DigitalCubicTask.API.DTO
{
    public class TaskSaveDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public Int64 assigned_user_id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
