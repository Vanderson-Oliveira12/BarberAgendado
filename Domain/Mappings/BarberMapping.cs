using BarberAgendado.Domain.DTOs.Barber;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Domain.Mappings
{
    public static class BarberMapping
    {
        public static BarberResponseDTO ToDTO(this Barber barber)
            => new BarberResponseDTO
            {
                Id = barber.Id,
                Name = barber.Name,
                CreatedAt = barber.CreatedAt,
                UpdatedAt = barber.UpdatedAt
            };

        public static IEnumerable<BarberResponseDTO> ToListDTO(this IEnumerable<Barber> barbers)
            => barbers.Select(ToDTO);

        public static Barber ToModel(this BarberCreateDTO dto)
            => new Barber
            {
                Name = dto.Name,
            };
    }
}
