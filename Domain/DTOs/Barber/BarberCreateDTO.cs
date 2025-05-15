using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.DTOs.Barber
{
    public class BarberCreateDTO
    {
        [Required]
        [MaxLength(244)]
        public string Name { get; set; }
    }
}
