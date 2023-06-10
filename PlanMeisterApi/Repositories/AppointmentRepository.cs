using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.Models;

namespace PlanMeisterApi.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly PlanMeisterDbContext _dbContext;

    public AppointmentRepository(PlanMeisterDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Appointment> GetAppointmentById(int appointmentId)
    {
        return await _dbContext.Appointments.FindAsync(appointmentId);
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointments()
    {
        return await _dbContext.Appointments.ToListAsync();
    }
    
    public async Task<IEnumerable<Appointment>> GetAppointmentsByDay(int dayScheduleId)
    {
        return await _dbContext.Appointments
            .Where(appointment => appointment.DayScheduleId == dayScheduleId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Appointment>> GetAppointmentsByEmployee(int employeeId)
    {
        return await _dbContext.Appointments
            .Where(appointment => appointment.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task AddAppointment(Appointment appointment)
    {
        await _dbContext.Appointments.AddAsync(appointment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAppointment(Appointment appointment)
    {
        _dbContext.Entry(appointment).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAppointment(int appointmentId)
    {
        var appointment = await _dbContext.Appointments.FindAsync(appointmentId);
        _dbContext.Appointments.Remove(appointment);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> AppointmentExists(int appointmentId)
    {
        return await _dbContext.Appointments.AnyAsync(a => a.AppointmentId == appointmentId);
    }

}