using System.ComponentModel.DataAnnotations;

namespace Demo_App.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string VehicleNo { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CustomerName { get; set; }
        public string ServiceAdvisorId { get; set; }
        public string OrderStatus { get; set; }
        public string Contact {  get; set; }

    }
}
