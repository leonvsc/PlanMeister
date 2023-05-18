using PlanMeisterApi.Enum;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.DTO;

public class AppointmentDto
{
    public int AppointmentId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AppointmentType Type { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public bool Billable { get; set; }
    public virtual DaySchedule DaySchedule { get; set; }
}