using PlanMeisterApi.DTO;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public interface IAppointmentRepository
{
    Task<Appointment> GetAppointmentById(int appointmentId);
    Task<IEnumerable<AppointmentDto>> GetAllAppointments();
    Task AddAppointment(Appointment appointment);
    Task UpdateAppointment(Appointment appointment);
    Task DeleteAppointment(int appointmentId);
    Task<bool> AppointmentExists(int appointmentId);
}
