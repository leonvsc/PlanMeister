using PlanMeisterApi.Models;

namespace PlanMeisterApi.DTO;

public class DayScheduleDto
{
    public int DayScheduleId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    public int WeekScheduleId { get; set; }
    public virtual WeekSchedule WeekSchedule { get; set; }
}