using PlanMeisterShared.Enum;

namespace PlanMeisterShared.Models;

public class Request
{
    public int RequestId { get; set; }
    public RequestType RequestType { get; set; }
    public string DateFrom { get; set; } // Maybe een date type?
    public string DateTill { get; set; } // Maybe een date type?
    public string TimeFrom { get; set; } // Maybe een time type?
    public string TimeTill { get; set; } // Maybe een time type?

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}