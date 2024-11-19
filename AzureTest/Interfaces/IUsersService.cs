using AzureTest.DTOs.Requests.Auth;
using AzureTest.Entities;

namespace AzureTest.Interfaces;

public interface IUsersService
{
    Task<IEnumerable<User>> GetUsers();
    Task AddUser(CreateUserRequest user);
    Task UpdateUser(int id, User user);
    Task DeleteUser(int id);
    Task<string> Login(LoginDTO dto);
}