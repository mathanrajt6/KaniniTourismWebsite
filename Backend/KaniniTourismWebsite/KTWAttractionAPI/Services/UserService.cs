using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using KTWAttractionAPI.Models.DTOs;

namespace KTWAttractionAPI.Services
{
    public class UserService : IUserAction
    {
        private readonly IBaseRepo<AttractionLikes, int> _attractionLikesRepo;
        private readonly IRepo<Attraction, int> _attractionRepo;

        public UserService(IBaseRepo<AttractionLikes,int> attractionLikesRepo, IRepo<Attraction,int> attractionRepo ) {
            _attractionLikesRepo = attractionLikesRepo;
            _attractionRepo = attractionRepo;
        }
        public async Task<Attraction?> AddAttraction(Attraction item)
        {
            return await _attractionRepo.Add(item);
        }

        public async Task<AttractionLikes?> AddLike(AttractionLikes item)
        {
            var attraction = await _attractionRepo.Get(item.AttractionId);
            var attractionLikes = await _attractionLikesRepo.GetAll();
            var attractionLike = attractionLikes?.Where(a => a.UserId == item.UserId && a.AttractionId == item.AttractionId).FirstOrDefault();
            if (attractionLike != null)
            {
                return null;
            }
            if (attraction != null )
            {
                attraction.Likes++;
                await _attractionRepo.Update(attraction);
                return await _attractionLikesRepo.Add(item);

            }
            return null;
        }

        public async Task<Attraction?> DeleteAttraction(AttractionDTO attractionDTO)
        {
            return await _attractionRepo.Delete(attractionDTO.AttractionId);
        }

        public async Task<ICollection<Attraction>?> GetAllAttractions()
        {
            return await _attractionRepo.GetAll();
        }

        public async Task<ICollection<Attraction>?> GetAllAttractionsByUser(AttractionDTO attractionDTO)
        {
            var attractions = await _attractionRepo.GetAll();
            return attractions?.Where(a => a.UserId == attractionDTO.UserId).ToList();
        }

        public async Task<ICollection<AttractionLikes>?> GetAllLikedAttractionbyUser(AttractionLikesDTO attractionLikesDTO)
        {
            var attractionLikes = await _attractionLikesRepo.GetAll();
            return attractionLikes?.Where(a => a.UserId == attractionLikesDTO.UserId).ToList();
        }

        public async Task<AttractionLikes?> RemoveLike(AttractionLikesDTO attractionLikesDTO)
        {
            var attraction = await _attractionRepo.Get(attractionLikesDTO.AttractionId);
            var attractionLikes = await _attractionLikesRepo.GetAll();
            var attractionLike = attractionLikes?.Where(a => a.UserId == attractionLikesDTO.UserId && a.AttractionId == attractionLikesDTO.AttractionId).FirstOrDefault();
            if (attraction != null && attractionLike != null)
            {
                attraction.Likes--;
                await _attractionRepo.Update(attraction);
                return await _attractionLikesRepo.Delete(attractionLike.AttractionLikeId);

            }
            return null;
        }


        public async Task<Attraction?> UpdateAttraction(AttractionUpdateDTO attractionUpdateDTO)
        {
            var attraction =  await _attractionRepo.Get(attractionUpdateDTO.AttractionId);
            if (attraction != null)
            {
                attraction.AttractionDescription = attractionUpdateDTO.AttractionDescription;
                return await _attractionRepo.Update(attraction);
            }
            return null;
        }
    }
}
