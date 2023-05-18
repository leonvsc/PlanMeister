using PlanMeisterWeb.Enum;

namespace PlanMeisterWeb.Models;

public class AppointmentModel
{
    public int AppointmentId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AppointmentType Type { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public bool Billable { get; set; }
    
    public int DayScheduleId { get; set; }
    public int EmployeeId { get; set; }
}