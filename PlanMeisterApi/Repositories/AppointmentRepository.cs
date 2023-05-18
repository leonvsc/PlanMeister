using Microsoft.EntityFrameworkCore;
using PlanMeisterApi.DTO;
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

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointments()
    {
        return await _dbContext.Appointments
            .Include(e => e.DaySchedule)
            .Select(x => new AppointmentDto()
            {
                AppointmentId = x.AppointmentId,
                Title = x.Title,
                Description = x.Description,
                Type = x.Type,
                StartDateTime = x.StartDateTime,
                EndDateTime = x.EndDateTime,
                Billable = x.Billable,
                DaySchedule = x.DaySchedule
            })
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