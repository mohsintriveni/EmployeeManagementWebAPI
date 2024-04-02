using EmployeeManagement.Data;
using EmployeeManagement.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Repository
{
    public class CityRepository:ICityRepository
    {
        private readonly DataContext _context;
        public CityRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<City>> GetCity(int Id)
        {
            var state = await _context.Cities
           .Where(s => s.StateId == Id)
           .ToListAsync();
            return state;
        }

        public async Task<City> GetCityById(int Id)
        {
            var city = await _context.Cities
           .Where(c => c.Id == Id).FirstOrDefaultAsync();
            return city;
        }
    }
}
