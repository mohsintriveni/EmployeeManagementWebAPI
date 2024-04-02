﻿using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    public interface IStateService
    {
        Task<List<State>> GetState(int Id);
        Task<State> GetStateById(int Id);

    }
}
