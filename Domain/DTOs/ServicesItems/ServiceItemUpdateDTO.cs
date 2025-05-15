namespace BarberAgendado.Domain.DTOs.ServicesItems
{
    public class ServiceItemUpdateDTO
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
