using EmployeeManagement.Data;
using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class CountryRepository:ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Country>> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return countries;
        }
    }
}
