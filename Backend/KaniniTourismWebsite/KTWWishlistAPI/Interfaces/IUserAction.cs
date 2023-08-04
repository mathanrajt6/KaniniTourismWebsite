using KTWWishlistAPI.Models;
using KTWWishlistAPI.Models.DTOs;

namespace KTWWishlistAPI.Interfaces
{
    public interface IUserAction
    {
        public Task<WishList?> AddWishList(WishList wishList);
        public Task<ICollection<WishList>?> GetAllWishListByuserID(WishlistDTO wishlistDTO );
        public Task<int> DeleteWishList(WishlistDTO wishlistDTO);
    }
}
