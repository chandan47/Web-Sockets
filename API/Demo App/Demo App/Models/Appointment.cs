using System.ComponentModel.DataAnnotations;

namespace Demo_App.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string VehicleNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CustomerName { get; set; }
        public string ServiceAdvisorId { get; set; }
        public string Contact { get; set; }
    }
}
