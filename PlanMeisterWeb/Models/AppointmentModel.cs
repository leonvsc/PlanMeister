using PlanMeisterWeb.Enum;

namespace PlanMeisterWeb.Models;

public class AppointmentModel
{
    public int AppointmentId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public AppointmentType Type { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public bool Billable { get; set; }
}