using PlanMeisterApi.Models;

namespace PlanMeisterApi.Services;

public interface IAppointmentService
{
    Task<Appointment> GetAppointmentById(int appointmentId);
    Task<IEnumerable<Appointment>> GetAllAppointments();
    Task<IEnumerable<Appointment>> GetAppointmentsByDay(int dayScheduleId);
    Task<IEnumerable<Appointment>> GetAppointmentsByEmployee(int employeeId);
    Task AddAppointment(Appointment appointment);
    Task UpdateAppointment(Appointment appointment);
    Task DeleteAppointment(int appointmentId);
    Task<bool> AppointmentExists(int appointmentId);
}