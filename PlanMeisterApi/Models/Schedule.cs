namespace PlanMeisterApi.Models;

public class Schedule
{
    public int ScheduleId { get; set; }

    public int DayId { get; set; }
    public Day Day { get; set; }
}