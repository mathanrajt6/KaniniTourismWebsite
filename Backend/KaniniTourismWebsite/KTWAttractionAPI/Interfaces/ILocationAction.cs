using KTWAttractionAPI.Models;
using KTWAttractionAPI.Models.DTOs;
using System.Diagnostics.Metrics;

namespace KTWAttractionAPI.Interfaces
{
    public interface ILocationAction
    {
        public Task<List<LocationDTO>?> GetALLStates();
        public Task<List<LocationDTO>?> GetALLCity();
        public Task<List<LocationDTO>?> GetAllCountry();
        public Task<Country?> GetACountry(LocationDTO locationDTO);
        public Task<City?> GetCity(LocationDTO locationDTO);
        public Task<State?> GetState(LocationDTO locationDTO);


    }
}
