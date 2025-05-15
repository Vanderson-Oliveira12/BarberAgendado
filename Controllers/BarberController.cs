using BarberAgendado.Domain.DTOs.Barber;
using BarberAgendado.Domain.Models;
using BarberAgendado.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberAgendado.Controllers
{
    [Route("api/barbers")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        public BarberService _barberService { get; set; }

        public BarberController(BarberService barberService)
        {
            _barberService = barberService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllAsync()
        {
            var barbers = await _barberService.GetAll();

            return Ok(ApiResponse.Success(barbers));
        }


        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<ActionResult<ApiResponse>> GetByIdAsync(string id)
        {
            var barber = await _barberService.GetByIdAsync(id);

            return barber != null ? Ok(ApiResponse.Success(barber)) : NotFound(ApiResponse.Error("Barbeiro não encontrado"));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateAsync([FromBody] BarberCreateDTO payload)
        {
            var createdBarber = await _barberService.CreateAsync(payload);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdBarber.Id }, createdBarber);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ApiResponse>> UpdateAsync(string id, [FromBody] BarberUpdateDTO dto)
        {
            if (id is null) return BadRequest(ApiResponse.Error("Id não pode ser nulo", 400));

            var updatedData = await _barberService.UpdateAsync(id, dto);

            return Ok(ApiResponse.Success(updatedData));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id is null) return BadRequest(ApiResponse.Error("Id não pode ser nulo", 400));

            await _barberService.RemoveAsync(id);

            return NoContent();
        }

    }
}
