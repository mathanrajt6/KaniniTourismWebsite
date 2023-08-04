using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KTWAttractionAPI.Services
{
    public class AttractionLikesRepo : IBaseRepo<AttractionLikes, int>
    {
        private readonly db_LocationsContext _context;

        public AttractionLikesRepo(db_LocationsContext context)
        {
            _context = context;
        }
        public async Task<AttractionLikes?> Add(AttractionLikes item)
        {
            if(_context.AttractionLikes != null)
            {
                await _context.AttractionLikes.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<AttractionLikes?> Delete(int id)
        {
            if(_context.AttractionLikes != null)
            {
                var item = await _context.AttractionLikes.FirstOrDefaultAsync(x => x.AttractionLikeId == id);
                if(item != null)
                {
                    _context.AttractionLikes.Remove(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            return null;
        }

        public async Task<ICollection<AttractionLikes>?> GetAll()
        {
            if(_context.AttractionLikes != null)
            {
                return await _context.AttractionLikes.ToListAsync();
            }
            return null;
        }
    }
}
