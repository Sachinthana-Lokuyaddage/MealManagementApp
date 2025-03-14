namespace MealManagementApp.Client.Dtos
{
    public class EmployeeMealDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? RFID { get; set; }
        public string? BreakTime { get; set; } = string.Empty;
        public string? StationId { get; set; } = string.Empty;
    }
}
