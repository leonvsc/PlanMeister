using PlanMeisterApi.Enum;

namespace PlanMeisterApi.Models;

public class Appointment
{
    public int AppointmentId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AppointmentType Type { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public bool Billable { get; set; }

    public int DayScheduleId { get; set; }
    public DaySchedule DaySchedule { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
