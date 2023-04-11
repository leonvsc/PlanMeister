using PlanMeisterApi.Enum;

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

    public static IEnumerable<Appointment> GetAppointmentSeeds()
    {
        var appointment = new List<Appointment>()
        {
            new Appointment()
            {
                AppointmentId = 1,
                Name = "Ziggo Playout",
                Description = "Ziggo Playout Ochtenddienst",
                Type = "Ziggo Playout",
                Task = "Ziggo Playout",
                Date = new DateTime(2023, 4, 1),
                Time = new TimeSpan(7, 45, 0),
                Billable = true,
                DayId = 1,
                EmployeeId = 1,
            },

            new Appointment()
            {
                AppointmentId = 2,
                Name = "Ziggo Playout",
                Description = "Ziggo Playout Avonddienst",
                Type = "Ziggo Playout",
                Task = "Ziggo Playout",
                Date = new DateTime(2023, 4, 1),
                Time = new TimeSpan(15, 45, 0),
                Billable = true,
                DayId = 2,
                EmployeeId = 2,
            },

            new Appointment()
            {
                AppointmentId = 3,
                Name = "Ziggo Playout",
                Description = "Ziggo Playout Nachtdienst",
                Type = "Ziggo Playout",
                Task = "Ziggo Playout",
                Date = new DateTime(2023, 4, 1),
                Time = new TimeSpan(23, 45, 0),
                Billable = true,
                DayId = 3,
                EmployeeId = 3,
            }
        };

        return appointment;
    }


    public static IEnumerable<Day> GetDaySeeds()
    {
        var appointments = GetAppointmentSeeds().ToList();

        var days = new List<Day>()
        {
            new Day()
            {
                DayId = 1,
                Name = "Maandag"
            },

            new Day()
            {
                DayId = 2,
                Name = "Dinsdag"
            },

            new Day()
            {
                DayId = 3,
                Name = "Woensdag"
            },
        };

        return days;
    }



    public static IEnumerable<Schedule> GetScheduleSeeds()
    {
        var schedule = new List<Schedule>()
        {
            new Schedule()
            {
                ScheduleId = 1,
                DayId = 1
            },

            new Schedule()
            {
                ScheduleId = 2,
                DayId = 2
            },

            new Schedule()
            {
                ScheduleId = 3,
                DayId = 3
            }
        };

        return schedule;
    }

    public static IEnumerable<Request> GetRequestSeeds()
    {
        var request = new List<Request>()
        {
            new Request()
            {
                RequestId = 1,
                EmployeeId = 1,
                RequestType = RequestType.Vakantie,
                DateFrom = "01-04-2023",
                DateTill = "10-04-2023",
                TimeFrom = "00:00",
                TimeTill = "23:59"
            },

            new Request()
            {
                RequestId = 2,
                EmployeeId = 2,
                RequestType = RequestType.Vakantie,
                DateFrom = "01-04-2023",
                DateTill = "10-04-2023",
                TimeFrom = "00:00",
                TimeTill = "23:59"
            },

            new Request()
            {
                RequestId = 3,
                EmployeeId = 3,
                RequestType = RequestType.Vakantie,
                DateFrom = "01-04-2023",
                DateTill = "10-04-2023",
                TimeFrom = "00:00",
                TimeTill = "23:59"
            },
        };

        return request;
    }


}