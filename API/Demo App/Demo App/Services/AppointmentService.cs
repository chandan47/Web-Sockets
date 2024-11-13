using Demo_App.Database;
using Demo_App.Implementation;
using Demo_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_App.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DataContext _dataContext;
        public AppointmentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _dataContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _dataContext.Appointments.FindAsync(id);
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            _dataContext.Appointments.Add(appointment);
            await _dataContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> UpdateAppointmentAsync(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return false;
            }

            _dataContext.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AppointmentExistsAsync(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment = await _dataContext.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return false;
            }

            _dataContext.Appointments.Remove(appointment);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        private async Task<bool> AppointmentExistsAsync(int id)
        {
            return await _dataContext.Appointments.AnyAsync(e => e.AppointmentId == id);
        }
    }
}
