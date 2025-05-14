using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.DTOs.Customers
{
    public class CustomerUpdateDTO
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
