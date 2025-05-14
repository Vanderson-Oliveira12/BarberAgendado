using BarberAgendado.Domain.DTOs;
using BarberAgendado.Domain.DTOs.CustomerDTOs;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Domain.Mappings
{
    public static class CustomerMapping
    {
        public static CustomerResponseDTO ToDTO(this Customer customer) =>
            new CustomerResponseDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Telefone = customer.Telefone,
            };

        public static IEnumerable<CustomerResponseDTO> ToListDTO(this IEnumerable<Customer> customers)
            => customers.Select(ToDTO);

        public static Customer ToModel(this CustomerCreateDTO dto) =>
            new Customer
            {
                Name = dto.Name,
                Email = dto.Email,
                Telefone = dto.Telefone,
            };
    }
}
