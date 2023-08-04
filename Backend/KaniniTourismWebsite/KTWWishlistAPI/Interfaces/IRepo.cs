using KTWWishlistAPI.Models;

namespace KTWWishlistAPI.Interfaces
{
    public interface IRepo
    {
        public Task<ICollection<WishList>?> GetAll();
        public Task<WishList?> Add(WishList wishList);
        public Task<int> Delete(int id);



    }
}
