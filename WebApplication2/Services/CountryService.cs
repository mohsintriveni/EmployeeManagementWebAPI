using EmployeeManagement.Entities;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<List<Country>> GetCountries()
        {
            return await _countryRepository.GetCountries();
        }
        public async Task<Country> GetCountryById(int Id)
        {
            return await _countryRepository.GetCountryById(Id);
        }
        
    }
}
