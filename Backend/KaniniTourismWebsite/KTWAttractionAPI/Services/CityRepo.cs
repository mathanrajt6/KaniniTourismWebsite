using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KTWAttractionAPI.Services
{
    public class CityRepo : ICommonRepo<City, int>
    {
        private db_LocationsContext _context;

        public CityRepo(db_LocationsContext context)
        {
            _context = context;
        }
        public async Task<ICollection<City>?> GetAll()
        {
            if( _context.Cities != null )
            {
                return await _context.Cities.ToListAsync();
            }
            return null;
        }
    }
}
