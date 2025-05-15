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
        public async Task<ActionResult> GetByIdAsync(string id)
        {
            var barber = await _barberService.GetByIdAsync(id);

            return barber != null ? Ok(barber) : NotFound(); 
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateAsync([FromBody] BarberCreateDTO payload)
        {
            var createdBarber = await _barberService.CreateAsync(payload);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdBarber.Id }, createdBarber);
        }

    }
}
