namespace PlanMeisterShared.Models;

public class WeekSchedule
{
    public int WeekScheduleId { get; set; }
    public int WeekNumber { get; set; }

    public ICollection<DaySchedule>? DaySchedules { get; set; }
}