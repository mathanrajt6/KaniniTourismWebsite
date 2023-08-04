using KTWWishlistAPI.Interfaces;
using KTWWishlistAPI.Models;
using KTWWishlistAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KTWWishlistAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IUserAction _userAction;

        public WishListController(IUserAction userAction)
        {
            _userAction = userAction;
        }

        [HttpPost]
        [ProducesResponseType(typeof(WishList), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WishList?>> Add(WishList wishList)
        {
            try
            {
                var result = await _userAction.AddWishList(wishList);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(WishlistDTO wishlistDTO)
        {
            try
            {
                var result = await _userAction.DeleteWishList(wishlistDTO);
                if (result != null)
                {
                    return Accepted();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(List<WishList>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<WishList>?>> GetAllWishListBuUser(WishlistDTO wishlistDTO)
        {
            try
            {
                var result = await _userAction.GetAllWishListByuserID(wishlistDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
