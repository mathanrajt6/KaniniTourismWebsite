using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KTWAttractionAPI.Services
{
    public class CountryRepo : ICommonRepo<Country, int>
    {
        private db_LocationsContext _context;

        public CountryRepo(db_LocationsContext  context)
        {
            _context = context;
        }
        public async Task<ICollection<Country>?> GetAll()
        {
            if(_context.Countries != null)
            {
                return await _context.Countries.ToListAsync();
            }
            return null;
        }
    }
}
