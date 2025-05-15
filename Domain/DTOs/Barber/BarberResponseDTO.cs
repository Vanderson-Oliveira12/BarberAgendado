using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.DTOs.Barber
{
    public class BarberResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
