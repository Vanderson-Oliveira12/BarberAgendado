using BarberAgendado.Data.Repositories.Interfaces;
using BarberAgendado.Domain.DTOs;
using BarberAgendado.Domain.DTOs.CustomerDTOs;
using BarberAgendado.Domain.Exceptions;
using BarberAgendado.Domain.Mappings;
using BarberAgendado.Domain.Models;

namespace BarberAgendado.Domain.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetAllAsync()
        {
            var customers =
                await _customerRepository.GetAllAsync();


            return customers.ToListDTO();
        }

        public async Task<CustomerResponseDTO> GetByIdAsync(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            return customer.ToDTO();
        }

        public async Task<CustomerResponseDTO> CreateAsync(CustomerCreateDTO dto)
        {
            var emailAlreadyExists = await _customerRepository.GetByEmailAsync(dto.Email);

            if (emailAlreadyExists != null) throw new BusinessLogicException("Usuário com esse e-mail já registrado");


            var customer = dto.ToModel();

            var createdCustomer = await _customerRepository.CreateAsync(customer);

            return createdCustomer.ToDTO();
        }

        public async Task<Customer> UpdateAsync(string id, Customer dto)
        {
            var customerExists = await _customerRepository.GetByIdAsync(id);

            if (customerExists is null) throw new BusinessLogicException("Usuário não encontrado");

            customerExists.Name = dto.Name;
            customerExists.Telefone = dto.Telefone;
            customerExists.UpdatedAt = DateTime.Now;

            await _customerRepository.UpdateAsync(customerExists);

            return customerExists;
        }

        public async Task<Customer> DeleteAsync(string id)
        {
            var customerExists = await _customerRepository.GetByIdAsync(id);

            if (customerExists is null) throw new BusinessLogicException("Usuário não encontrado");

            await _customerRepository.RemoveAsync(customerExists);

            return customerExists;
        }


    }
}
