using PlanMeisterApi.Models;
using PlanMeisterApi.Repositories;

namespace PlanMeisterApi.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }
    
    public async Task<Appointment> GetAppointmentById(int appointmentId)
    {
        return await _appointmentRepository.GetAppointmentById(appointmentId);
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointments()
    {
        return await _appointmentRepository.GetAllAppointments();
    }
    
    public async Task<IEnumerable<Appointment>> GetAppointmentsByDay(int dayScheduleId)
    {
        return await _appointmentRepository.GetAppointmentsByDay(dayScheduleId);
    }

    public async Task AddAppointment(Appointment appointment)
    {
        await _appointmentRepository.AddAppointment(appointment);
    }

    public async Task UpdateAppointment(Appointment appointment)
    {
        if (!await _appointmentRepository.AppointmentExists(appointment.AppointmentId))
        {
            throw new Exception("Appointment not found.");
        }
        await _appointmentRepository.UpdateAppointment(appointment);
    }

    public async Task DeleteAppointment(int appointmentId)
    {
        await _appointmentRepository.DeleteAppointment(appointmentId);
    }
    
    public async Task<bool> AppointmentExists(int appointmentId)
    {
        return await _appointmentRepository.AppointmentExists(appointmentId);
    }

}