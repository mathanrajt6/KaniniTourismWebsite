using KTWWishlistAPI.Interfaces;
using KTWWishlistAPI.Models;
using KTWWishlistAPI.Models.DTOs;

namespace KTWWishlistAPI.Services
{
    public class UserService : IUserAction
    {
        private readonly IRepo _repo;

        public UserService(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<WishList?> AddWishList(WishList wishList)
        {
            return await _repo.Add(wishList);
        }

        public async Task<int> DeleteWishList(WishlistDTO wishlistDTO)
        {
            return await _repo.Delete(wishlistDTO.WishlistId);
        }

        public async Task<ICollection<WishList>?> GetAllWishListByuserID(WishlistDTO wishlistDTO)
        {
            var wishLists = await _repo.GetAll();
            return wishLists?.Where(w => w.UserId == wishlistDTO.UserId).ToList();
        }
    }
}
