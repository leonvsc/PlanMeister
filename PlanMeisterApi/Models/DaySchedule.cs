namespace PlanMeisterApi.Models;

public class DaySchedule
{
    public int DayScheduleId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public DateTime Date { get; set; }
    public int WeekScheduleId { get; set; }
    public WeekSchedule? WeekSchedule { get; set; }
    
    public ICollection<Appointment>? Appointments { get; set; }
}