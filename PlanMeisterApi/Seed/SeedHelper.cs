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
                Title = "Ziggo Playout",
                Description = "Ziggo Playout Ochtenddienst",
                Type = AppointmentType.Ochtenddienst,
                StartDateTime = new DateTime(2023, 4, 1,07,45,00),
                EndDateTime = new DateTime(2023,4,1,16,00,00),
                Billable = true,
                DayScheduleId = 1,
                EmployeeId = 1,
            },

            new Appointment()
            {
                AppointmentId = 2,
                Title = "Ziggo Playout",
                Description = "Ziggo Playout Avonddienst",
                Type = AppointmentType.Avonddienst,
                StartDateTime = new DateTime(2023, 4, 1,15,45,00),
                EndDateTime = new DateTime(2023,4,2,00,00,00),
                Billable = true,
                DayScheduleId = 2,
                EmployeeId = 2,
            },

            new Appointment()
            {
                AppointmentId = 3,
                Title = "Ziggo Playout",
                Description = "Ziggo Playout Nachtdienst",
                Type = AppointmentType.Nachtdienst,
                StartDateTime = new DateTime(2023, 4, 1,23,45,00),
                EndDateTime = new DateTime(2023,4,2,08,00,00),
                Billable = true,
                DayScheduleId = 3,
                EmployeeId = 3,
            }
        };

        return appointment;
    }


    public static IEnumerable<DaySchedule> GetDaySeeds()
    {
        var appointments = GetAppointmentSeeds().ToList();

        var days = new List<DaySchedule>()
        {
            new DaySchedule()
            {
                DayScheduleId = 1,
                DayOfWeek = DayOfWeek.Monday,
                Date = new DateTime(23,05,22),
                WeekScheduleId = 1
            },

            new DaySchedule()
            {
                DayScheduleId = 2,
                DayOfWeek = DayOfWeek.Tuesday,
                Date = new DateTime(23,05,23),
                WeekScheduleId = 1
            },

            new DaySchedule()
            {
                DayScheduleId = 3,
                DayOfWeek = DayOfWeek.Wednesday,
                Date = new DateTime(23,05,24),
                WeekScheduleId = 1
            },
        };

        return days;
    }



    public static IEnumerable<WeekSchedule> GetScheduleSeeds()
    {
        var schedule = new List<WeekSchedule>()
        {
            new WeekSchedule()
            {
                WeekScheduleId = 1,
                WeekNumber = 1
            },

            new WeekSchedule()
            {
                WeekScheduleId = 2,
                WeekNumber = 2
            },

            new WeekSchedule()
            {
                WeekScheduleId = 3,
                WeekNumber = 3
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