using BarberAgendado.Domain.DTOs.ServicesItems;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Domain.Mappings
{
    public static class ServiceItemMapping
    {
        public static ServiceItemResponseDTO ToDTO(this ServiceItem serviceItem)
            => new ServiceItemResponseDTO
            {
                Id = serviceItem.Id,
                Name = serviceItem.Name,
                Duration = serviceItem.Duration,
                Price = serviceItem.Price,
            };

        public static IEnumerable<ServiceItemResponseDTO> ToListDTO(this IEnumerable<ServiceItem> servicesItems)
            => servicesItems.Select(ToDTO);

        public static ServiceItem ToModel(this ServiceItemCreateDTO dto)
            => new ServiceItem
            {
                Name = dto.Name,
                Duration = dto.Duration,
                Price = dto.Price,
            };
    }
}
