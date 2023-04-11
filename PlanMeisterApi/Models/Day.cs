namespace PlanMeisterApi.Models;

public class Day
{
    public int DayId { get; set; }
    public string Name { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}