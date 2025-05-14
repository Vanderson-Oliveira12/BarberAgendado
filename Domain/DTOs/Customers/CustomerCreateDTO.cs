using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.DTOs.CustomerDTOs
{
    public class CustomerCreateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
