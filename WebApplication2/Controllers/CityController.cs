using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("get-cities-by-state")]
        public async Task<ActionResult<IEnumerable<City>>> GetCityByStates(int Id)
        {
            try
            {
                var cities = await _cityService.GetCity(Id);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("get-city-by-id/{Id}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCityById(int Id)
        {
            try
            {
                var city= await _cityService.GetCityById(Id);
                return Ok(city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
