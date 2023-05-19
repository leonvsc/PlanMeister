namespace PlanMeisterApi.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<Appointment> Appointments { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
}