using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KTWAttractionAPI.Services
{
    public class StateRepo : ICommonRepo<State, int>
    {
        private db_LocationsContext _context;

        public StateRepo(db_LocationsContext context)
        {
            _context = context;
        }
        public async Task<ICollection<State>?> GetAll()
        {
            if(_context.States != null)
            {
                return await _context.States.ToListAsync();
            }
            return null;
        }
    }
}
