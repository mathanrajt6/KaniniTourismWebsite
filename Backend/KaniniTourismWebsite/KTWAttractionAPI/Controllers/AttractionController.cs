using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using KTWAttractionAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KTWAttractionAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttractionController : ControllerBase
    {
        private readonly IUserAction _userAction;

        public AttractionController(IUserAction userAction)
        {
            _userAction = userAction;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Attraction),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAttraction(Attraction item)
        {
            var attraction = await _userAction.AddAttraction(item);
            if (attraction != null)
            {
                return Ok(attraction);
            }
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(AttractionLikes), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddLike(AttractionLikes item)
        {
            var attractionLikes = await _userAction.AddLike(item);
            if (attractionLikes != null)
            {
                return Ok(attractionLikes);
            }
            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Attraction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAttraction(AttractionDTO attractionDTO)
        {
            var attraction = await _userAction.DeleteAttraction(attractionDTO);
            if (attraction != null)
            {
                return Ok(attraction);
            }
            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(AttractionLikes), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveLike(AttractionLikesDTO attractionLikesDTO)
        {
            var attractionLikes = await _userAction.RemoveLike(attractionLikesDTO);
            if (attractionLikes != null)
            {
                return Ok(attractionLikes);
            }
            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Attraction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAttractions()
        {
            var attractions = await _userAction.GetAllAttractions();
            if (attractions != null)
            {
                return Ok(attractions);
            }
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Attraction>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAttractionsByUser(AttractionDTO attractionDTO)
        {
            var attractions = await _userAction.GetAllAttractionsByUser(attractionDTO);
            if (attractions != null)
            {
                return Ok(attractions);
            }
            return BadRequest();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ICollection<AttractionLikes>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllLikedAttractionbyUser(AttractionLikesDTO attractionLikesDTO)
        {
            var attractionLikes = await _userAction.GetAllLikedAttractionbyUser(attractionLikesDTO);
            if (attractionLikes != null)
            {
                return Ok(attractionLikes);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Attraction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAttraction(AttractionUpdateDTO attractionUpdateDTO)
        {
            var attraction = await _userAction.UpdateAttraction(attractionUpdateDTO);
            if (attraction != null)
            {
                return Ok(attraction);
            }
            return BadRequest();
        }

       

       

    }
}
