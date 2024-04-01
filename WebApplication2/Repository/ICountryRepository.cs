using EmployeeManagement.Entities;

namespace EmployeeManagement.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetCountries();
    }
}
