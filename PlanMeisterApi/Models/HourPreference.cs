namespace PlanMeisterApi.Models;

public class HourPreference
{
    public int HourPreferenceId { get; set; }
    public int WeekNumber { get; set; }
    public int AmountOfHours { get; set; }
    
    public int EmployeeId { get; set; }
}