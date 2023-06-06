using PlanMeisterShared.Enum;

namespace PlanMeisterShared.Models;

public class Request
{
    public int RequestId { get; set; }
    public RequestType RequestType { get; set; }
    public DateTime DateTimeFrom { get; set; }
    public DateTime DateTimeTill { get; set; }
    public RequestStatus RequestStatus { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}