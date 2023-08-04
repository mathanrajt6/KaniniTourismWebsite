using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KTWAttractionAPI.Services
{
    public class AttractionRepo : IRepo<Attraction, int>
    {
        private readonly db_LocationsContext _context;
        public AttractionRepo(db_LocationsContext context)
        {
            _context = context;
        }
        public async Task<Attraction?> Add(Attraction item)
        {
            if(_context.Attractions != null)
            {
                await _context.Attractions.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Attraction?> Delete(int id)
        {
            if(_context.Attractions != null)
            {
                var item = await Get(id);
                if(item != null)
                {
                    _context.Attractions.Remove(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            return null;
        }

        public async Task<Attraction?> Get(int id)
        {
            if(_context.Attractions != null)
            {
                return await _context.Attractions.FirstOrDefaultAsync(x => x.AttractionId == id);
            }
            return null;
        }

        public async Task<ICollection<Attraction>?> GetAll()
        {
            if (_context.Attractions != null)
            {
                return await _context.Attractions.Include(a=>a.Speciality).ToListAsync();
            }
            return null;
        }

        public async Task<Attraction?> Update(Attraction item)
        {
            if(_context.Attractions != null)
            {
                _context.Attractions.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }
    }
}
