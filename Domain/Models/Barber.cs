using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.Models
{
    public class Barber : Entity
    {
        [Required]
        [MaxLength(244)]
        public string Name { get; set; }
    }
}
