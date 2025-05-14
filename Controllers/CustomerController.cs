using BarberAgendado.Domain.DTOs;
using BarberAgendado.Domain.DTOs.CustomerDTOs;
using BarberAgendado.Domain.Models;
using BarberAgendado.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberAgendado.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> Get()
        {
            var customers = await _customerService.GetAllAsync();

            return Ok(customers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetById(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            return customer != null ? Ok(customer) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerCreateDTO payload)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var customer =await _customerService.CreateAsync(payload);

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
