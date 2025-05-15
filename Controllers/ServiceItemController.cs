using BarberAgendado.Domain.DTOs.ServicesItems;
using BarberAgendado.Domain.Models;
using BarberAgendado.Domain.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberAgendado.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceItemController : ControllerBase
    {
        private ServiceItemService _serviceItemService;

        public ServiceItemController(ServiceItemService serviceItemService)
        {
            _serviceItemService = serviceItemService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            var servicesItems = await _serviceItemService.GetAllAsync();

            return Ok(ApiResponse.Success(servicesItems));
        }

        // GET api/<ServiceItemController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApiResponse>> GetById(string id)
        {
            if (id is null) return BadRequest(ApiResponse.Error("id obrigatório"));

            var serviceItem = await _serviceItemService.GetByIdAsync(id);


            return serviceItem is null ? NotFound(ApiResponse.Error("Serviço não encontrado")) : Ok(ApiResponse.Success(serviceItem));
        }

        // POST api/<ServiceItemController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ServiceItemCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdService = await _serviceItemService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createdService.Id }, createdService);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(string id, [FromBody] ServiceItemUpdateDTO dto)
        {
            if (id is null) return BadRequest(ApiResponse.Error("id obrigatório"));

            var updatedDto = await _serviceItemService.UpdateAsync(id, dto);

            return Ok(ApiResponse.Success(updatedDto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id is null) return BadRequest(ApiResponse.Error("id obrigatório"));

            await _serviceItemService.RemoveAsync(id);

            return NoContent();
        }
    }
}
