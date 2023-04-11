namespace PlanMeisterApi.Models;

public class Appointment
{
    public int AppointmentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Task { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public bool Billable { get; set; }

    public int DayId { get; set; }
    public Day Day { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
