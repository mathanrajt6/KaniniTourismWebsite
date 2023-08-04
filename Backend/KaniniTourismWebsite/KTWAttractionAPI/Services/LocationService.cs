using KTWAttractionAPI.Interfaces;
using KTWAttractionAPI.Models;
using KTWAttractionAPI.Models.DTOs;

namespace KTWAttractionAPI.Services
{
    public class LocationService : ILocationAction
    {
        private readonly ICommonRepo<Country, int> _countryRepo;
        private readonly ICommonRepo<City, int> _cityRepo;
        private readonly ICommonRepo<State, int> _stateRepo;

        public LocationService(ICommonRepo<Country,int> countryRepo, ICommonRepo<City, int> cityRepo , ICommonRepo<State, int> stateRepo)
        {
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
            _stateRepo = stateRepo;
        }
        public async Task<Country?> GetACountry(LocationDTO locationDTO)
        {
            var countries = await _countryRepo.GetAll();
            var country = countries?.FirstOrDefault(c=>c.Name == locationDTO.Name);
            return country;
        }

        public async Task<List<LocationDTO>?> GetALLCity()
        {
            var cities = await _cityRepo.GetAll();
            return cities?.Select( a=> new LocationDTO { Id= a.Id , Name = a.Name }).ToList();

        }

        public async Task<List<LocationDTO>?> GetAllCountry()
        {
            var countries = await _countryRepo.GetAll();
            return countries?.Select(a => new LocationDTO { Id = a.Id, Name = a.Name }).ToList();
        }

        public async Task<List<LocationDTO>?> GetALLStates()
        {
            var states = await _stateRepo.GetAll();
            return states?.Select(a => new LocationDTO { Id = a.Id, Name = a.Name }).ToList();
        }

        public async Task<City?> GetCity(LocationDTO locationDTO)
        {
            var cities = await _cityRepo.GetAll();
            var city = cities?.FirstOrDefault(c => c.Name == locationDTO.Name);
            return city;
        }

        public async Task<State?> GetState(LocationDTO locationDTO)
        {
            var states = await _stateRepo.GetAll();
            var state = states?.FirstOrDefault(c => c.Name == locationDTO.Name);
            return state;
        }
    }
}
