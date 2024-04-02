using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("get-states-by-country")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountry (int Id)
        {
            try
            {
                var states = await _stateService.GetState(Id);
                return Ok(states);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("get-state-by-id/{Id}")]
        public async Task<ActionResult<IEnumerable<State>>> GetStateById(int Id)
        {
            try
            {
                var state = await _stateService.GetStateById(Id);
                return Ok(state);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
