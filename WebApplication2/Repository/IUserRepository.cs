using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Repository
{
    public interface IUserRepository
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterVM user);
        Task<UserManagerResponse> LoginUserAsync(LoginVM user);
    }
}
