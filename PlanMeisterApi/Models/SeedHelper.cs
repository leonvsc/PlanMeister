namespace PlanMeisterApi.Models;

public class SeedHelper
{
    public static IEnumerable<Employee> GetEmployeeSeeds()
    {
        var employee = new List<Employee>()
        {
            new Employee()
            {
                EmployeeId = 1,
                Name = "Hans"
            },
            
            new Employee()
            {
                EmployeeId = 2,
                Name = "Klaas"
            },
            
            new Employee()
            {
                EmployeeId = 3,
                Name = "Piet"
            }
        };

        return employee;
    }
}