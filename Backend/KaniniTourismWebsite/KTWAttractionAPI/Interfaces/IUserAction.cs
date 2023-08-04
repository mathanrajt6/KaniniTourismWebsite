using KTWAttractionAPI.Models;
using KTWAttractionAPI.Models.DTOs;

namespace KTWAttractionAPI.Interfaces
{
    public interface IUserAction
    {
        public Task<AttractionLikes?> AddLike(AttractionLikes item);
        public Task<AttractionLikes?> RemoveLike(AttractionLikesDTO attractionLikesDTO);
        public Task<ICollection<AttractionLikes>?> GetAllLikedAttractionbyUser(AttractionLikesDTO attractionLikesDTO);
        public Task<Attraction?> AddAttraction(Attraction item);
        public Task<Attraction?> UpdateAttraction(AttractionUpdateDTO attractionUpdateDTO);
        public Task<Attraction?> DeleteAttraction(AttractionDTO attractionDTO);
        public Task<ICollection<Attraction>?> GetAllAttractionsByUser(AttractionDTO attractionDTO);
        public Task<ICollection<Attraction>?> GetAllAttractions();

    }
}
