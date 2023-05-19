namespace PlanMeisterApi.Models;

public class DaySchedule
{
    public int DayScheduleId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    public int WeekScheduleId { get; set; }
    public virtual WeekSchedule WeekSchedule { get; set; }
    
    public virtual ICollection<Appointment> Appointments { get; set; }
}