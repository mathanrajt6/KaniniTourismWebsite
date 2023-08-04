using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using KTWAttractionAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KTWAttractionAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationAction _locationAction;

        public LocationController(ILocationAction locationAction)
        {
            _locationAction = locationAction;
        }

        [HttpGet]
        [ProducesResponseType(typeof(LocationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<LocationDTO>?>> GetAllStates()
        {
            var result = await _locationAction.GetALLStates();
            if(result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }
        [HttpGet]
        [ProducesResponseType(typeof(LocationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<LocationDTO>?>> GetAllCities()
        {
            var result = await _locationAction.GetALLCity();
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType(typeof(LocationDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<LocationDTO>?>> GetAllCountry()
        {
            var result = await _locationAction.GetAllCountry();
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(State), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State?>> GetAState(LocationDTO locationDTO)
        {
            var result = await _locationAction.GetState(locationDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State?>> GetACountry(LocationDTO locationDTO)
        {
            var result = await _locationAction.GetACountry(locationDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(State), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State?>> GetACity(LocationDTO locationDTO)
        {
            var result = await _locationAction.GetCity(locationDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }



    }
}

