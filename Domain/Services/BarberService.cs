using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.DTOs.Barber;
using BarberAgendado.Domain.Exceptions;
using BarberAgendado.Domain.Mappings;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Domain.Services
{
    public class BarberService
    {
        public IBarberRepository _repository { get; set; }

        public BarberService(IBarberRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BarberResponseDTO>> GetAll()
        {
            var barbers = await _repository.GetAllAsync();

            return barbers.ToListDTO();
        }

        public async Task<BarberResponseDTO> GetByIdAsync(string id)
        {
            var barber = await _repository.GetByIdAsync(id);
            if (barber is null)
            {
                throw new BusinessLogicException("Barbeiro não encontrado");
            }

            return barber.ToDTO();
        }

        public async Task<BarberResponseDTO> CreateAsync(BarberCreateDTO dto)
        {
            var barber = dto.ToModel();

            var createdBarber = await _repository.CreateAsync(barber);

            return createdBarber.ToDTO();
        }

        public async Task<BarberResponseDTO> UpdateAsync(string id, BarberUpdateDTO dto)
        {
            var barber = await _repository.GetByIdAsync(id);
            if (barber is null)
            {
                throw new BusinessLogicException("Barbeiro não encontrado");
            }

            if (dto.Name != null) barber.Name = dto.Name;
            barber.UpdatedAt = DateTime.Now;


            await _repository.UpdateAsync(barber);

            return barber.ToDTO();
        }

        public async Task RemoveAsync(string id)
        {
            var barberExists = await _repository.GetByIdAsync(id);

            if (barberExists is null)
            {
                throw new BusinessLogicException("Usuário não encontrado");
            }

            await _repository.RemoveAsync(barberExists);
        }
    }
}
