namespace BarberAgendado.Domain.Models
{
    public class ServiceItem : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
