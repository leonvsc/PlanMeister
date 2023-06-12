using PlanMeisterApi.Enum;
using PlanMeisterShared.Enum;

namespace PlanMeisterApi.Models;

public class SeedHelper
{
    public static IEnumerable<Employee> GetEmployeeSeeds()
    {
        var employee = new List<Employee>
        {
            new()
            {
                EmployeeId = 1,
                Name = "Hans"
            },

            new()
            {
                EmployeeId = 2,
                Name = "Klaas"
            },

            new()
            {
                EmployeeId = 3,
                Name = "Piet"
            }
        };

        return employee;
    }

    public static IEnumerable<Appointment> GetAppointmentSeeds()
    {
        var appointment = new List<Appointment>
        {
            new()
            {
                AppointmentId = 1,
                Title = "Ziggo Playout",
                Description = "Ziggo Playout Ochtenddienst",
                Type = AppointmentType.MorningShift,
                StartDateTime = new DateTime(2023, 4, 1, 07, 45, 00),
                EndDateTime = new DateTime(2023, 4, 1, 16, 00, 00),
                Billable = true,
                DayScheduleId = 1,
                EmployeeId = 1
            },

            new()
            {
                AppointmentId = 2,
                Title = "Ziggo Playout",
                Description = "Ziggo Playout Avonddienst",
                Type = AppointmentType.EveningShift,
                StartDateTime = new DateTime(2023, 4, 1, 15, 45, 00),
                EndDateTime = new DateTime(2023, 4, 2, 00, 00, 00),
                Billable = true,
                DayScheduleId = 2,
                EmployeeId = 2
            },

            new()
            {
                AppointmentId = 3,
                Title = "Ziggo Playout",
                Description = "Ziggo Playout Nachtdienst",
                Type = AppointmentType.NightShift,
                StartDateTime = new DateTime(2023, 4, 1, 23, 45, 00),
                EndDateTime = new DateTime(2023, 4, 2, 08, 00, 00),
                Billable = true,
                DayScheduleId = 3,
                EmployeeId = 3
            }
        };

        return appointment;
    }


    public static IEnumerable<DaySchedule> GetDaySeeds()
    {
        var appointments = GetAppointmentSeeds().ToList();

        var days = new List<DaySchedule>
        {
            new()
            {
                DayScheduleId = 1,
                DayOfWeek = DayOfWeek.Monday,
                Date = new DateTime(2023, 05, 22),
                WeekScheduleId = 1
            },

            new()
            {
                DayScheduleId = 2,
                DayOfWeek = DayOfWeek.Tuesday,
                Date = new DateTime(2023, 05, 23),
                WeekScheduleId = 1
            },

            new()
            {
                DayScheduleId = 3,
                DayOfWeek = DayOfWeek.Wednesday,
                Date = new DateTime(2023, 05, 24),
                WeekScheduleId = 1
            }
        };

        return days;
    }


    public static IEnumerable<WeekSchedule> GetScheduleSeeds()
    {
        var schedule = new List<WeekSchedule>
        {
            new()
            {
                WeekScheduleId = 1,
                WeekNumber = 1
            },

            new()
            {
                WeekScheduleId = 2,
                WeekNumber = 2
            },

            new()
            {
                WeekScheduleId = 3,
                WeekNumber = 3
            }
        };

        return schedule;
    }

    public static IEnumerable<Request> GetRequestSeeds()
    {
        var request = new List<Request>
        {
            new()
            {
                RequestId = 1,
                EmployeeId = 1,
                RequestType = RequestType.Vacation,
                DateTimeFrom = new DateTime(2023, 04, 01),
                DateTimeTill = new DateTime(2023, 04, 10),
                RequestStatus = RequestStatus.Processing
            },

            new()
            {
                RequestId = 2,
                EmployeeId = 2,
                RequestType = RequestType.Vacation,
                DateTimeFrom = new DateTime(2023, 04, 01),
                DateTimeTill = new DateTime(2023, 04, 10),
                RequestStatus = RequestStatus.Processing
            },

            new()
            {
                RequestId = 3,
                EmployeeId = 3,
                RequestType = RequestType.Vacation,
                DateTimeFrom = new DateTime(2023, 04, 01),
                DateTimeTill = new DateTime(2023, 04, 10),
                RequestStatus = RequestStatus.Processing
            }
        };

        return request;
    }

    public static IEnumerable<HourPreference> GetHourPreferenceSeeds()
    {
        var hourPreference = new List<HourPreference>
        {
            new()
            {
                HourPreferenceId = 1,
                WeekNumber = 23,
                AmountOfHours = 32,
                HourPreferenceStatus = HourPreferenceStatus.Processing,
                EmployeeId = 1
            },

            new()
            {
                HourPreferenceId = 2,
                WeekNumber = 23,
                AmountOfHours = 40,
                HourPreferenceStatus = HourPreferenceStatus.Processing,
                EmployeeId = 2
            },

            new()
            {
                HourPreferenceId = 3,
                WeekNumber = 23,
                AmountOfHours = 24,
                HourPreferenceStatus = HourPreferenceStatus.Processing,
                EmployeeId = 3
            }
        };

        return hourPreference;
    }
}