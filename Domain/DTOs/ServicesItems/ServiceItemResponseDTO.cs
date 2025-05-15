namespace BarberAgendado.Domain.DTOs.ServicesItems
{
    public class ServiceItemResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
