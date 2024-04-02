using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountries();
        Task<Country> GetCountryById(int Id);
    }
}
