namespace PlanMeisterApi.Models;

public class WeekSchedule
{
    public int WeekScheduleId { get; set; }
    public int WeekNumber { get; set; }
    
    public virtual ICollection<DaySchedule> DaySchedules { get; set; }
}