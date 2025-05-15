using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.DTOs.Barber;
using BarberAgendado.Domain.DTOs.ServicesItems;
using BarberAgendado.Domain.Exceptions;
using BarberAgendado.Domain.Mappings;

namespace BarberAgendado.Domain.Services
{
    public class ServiceItemService
    {
        public IServiceItemRepository _repository { get; set; }

        public ServiceItemService(IServiceItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ServiceItemResponseDTO>> GetAllAsync()
        {
            var servicesItems = await _repository.GetAllAsync();

            return servicesItems.ToListDTO();
        }

        public async Task<ServiceItemResponseDTO> GetByIdAsync(string id)
        {
            var serviceItem = await _repository.GetByIdAsync(id);
            if (serviceItem is null)
            {
                throw new BusinessLogicException("Barbeiro não encontrado");
            }

            return serviceItem.ToDTO();
        }

        public async Task<ServiceItemResponseDTO> CreateAsync(ServiceItemCreateDTO dto)
        {
            var serviceAlreadyExists = await _repository.GetByNameAsync(dto.Name);
            if (serviceAlreadyExists != null)
                throw new BusinessLogicException("Nome do serviço já cadastrado.");

            var serviceItem = dto.ToModel();

            var createdService = await _repository.CreateAsync(serviceItem);

            return createdService.ToDTO();
        }

        public async Task<ServiceItemResponseDTO> UpdateAsync(string id, ServiceItemUpdateDTO dto)
        {
            var serviceItem = await _repository.GetByIdAsync(id);
            if (serviceItem is null)
            {
                throw new BusinessLogicException("Tipo de serviço não encontrado");
            }

            if (dto.Name != null) serviceItem.Name = dto.Name;
            if (dto.Duration != null) serviceItem.Duration = dto.Duration.Value;
            if (dto.Price != null) serviceItem.Price = dto.Price.Value;
            serviceItem.UpdatedAt = DateTime.Now;


            await _repository.UpdateAsync(serviceItem);

            return serviceItem.ToDTO();
        }

        public async Task RemoveAsync(string id)
        {
            //ajeitar aqui
            var barberExists = await _repository.GetByIdAsync(id);

            if (barberExists is null)
            {
                throw new BusinessLogicException("Usuário não encontrado");
            }

            await _repository.RemoveAsync(barberExists);
        }
    }
}
