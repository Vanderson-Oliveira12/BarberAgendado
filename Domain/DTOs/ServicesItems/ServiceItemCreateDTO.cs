using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.DTOs.ServicesItems
{
    public class ServiceItemCreateDTO
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }
    }
}
