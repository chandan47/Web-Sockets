using Demo_App.Models;

namespace Demo_App.Implementation
{
    public interface IAppointmentService
    {
        public Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        public Task<Appointment> GetAppointmentByIdAsync(int id);
        public Task<Appointment> CreateAppointmentAsync(Appointment appointment);
        public Task<bool> UpdateAppointmentAsync(int id, Appointment appointment);
        public Task<bool> DeleteAppointmentAsync(int id);
    }
}
