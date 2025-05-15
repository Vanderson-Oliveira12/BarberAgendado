using System.ComponentModel.DataAnnotations;

namespace BarberAgendado.Domain.DTOs.Customers
{
    public class CustomerUpdateDTO
    {
        public string? Name { get; set; }

        public string? Telefone { get; set; }
    }
}
