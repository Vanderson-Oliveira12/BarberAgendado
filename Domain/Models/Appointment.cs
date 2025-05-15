using System.ComponentModel.DataAnnotations.Schema;

namespace BarberAgendado.Domain.Models
{
    public class Appointment : Entity
    {
        public DateTime ScheduledAt { get; set; }
        public bool IsCompleted { get; set; }

        public string CustomerId { get; set; }
        public string BarberId { get; set; }
        public string ServiceItemId { get; set; }
        public Customer Customer { get; set; }
        public Barber Barber { get; set; }
        public ServiceItem ServiceItem { get; set; }
    }
}
