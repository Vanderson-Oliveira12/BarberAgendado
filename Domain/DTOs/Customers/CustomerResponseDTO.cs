using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.DTOs
{
    public class CustomerResponseDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
