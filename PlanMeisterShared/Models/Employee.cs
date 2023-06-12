namespace PlanMeisterShared.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<Request> Requests { get; set; }
}