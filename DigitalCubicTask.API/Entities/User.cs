using System.ComponentModel.DataAnnotations;

namespace DigitalCubicTask.API.Entities
{
    public class User
    {
        [Key]
        public Int64 User_Id { get; private set; }
        public string UserName { get; set; }
    }
}
