using System.ComponentModel.DataAnnotations;

namespace MealManagementApp.Models
{
    public class EmployeeMeal
    {
        [Key]
        //public Guid Id { get; set; } 
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? CreatedDateTime { get; set; } = DateTime.UtcNow;
        public string? RFID { get; set; }
        public string? BreakTime { get; set; } = string.Empty;
        public string? StationId { get; set; } = string.Empty;


        //public Guid Id { get; set; }
        //public DateTime CreatedDateTime { get; set; }  // No longer nullable
        //public string RFID { get; set; }               // Updated type to string
        //public string BreakTime { get; set; }
        //public string StationId { get; set; }

    }
}
