using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    public interface ICityService
    {
        Task<List<City>> GetCity(int Id);
        Task<City> GetCityById(int Id);
    }
}
