using AzureTest.DTOs.Requests.Auth;
using AzureTest.Entities;
using AzureTest.Interfaces;
using AzureTest.Utils;
using Microsoft.EntityFrameworkCore;

namespace AzureTest.Services;

public class UsersService : IUsersService
{
    private readonly Context _context;
    private readonly IAuthService _authService;

    public UsersService(Context context, IAuthService authService)
    {
        _context = context;
        _authService = authService;
        
    }
    
    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddUser(CreateUserRequest user)
    {
        if (user.Password != user.ConfirmPassword)
        {
            throw new Exception($"User with email {user.Email} already exists");
        }
        //|| await FindUser(user.Email) != null
        
        var hashPassword = _authService.HashPassword(user.Password);

        var newUser = new User()
        {
            Email = user.Email,
            Password = hashPassword,
            Name = user.Name,
        };
        
        await _context.Users.AddAsync(newUser);
        
        await _context.SaveChangesAsync();
    }

    public Task UpdateUser(int id, User user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteUser(int id)
    {
        var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (userExists == null)
        {
            throw new Exception("User not found");
        }

        _context.Users.Remove(userExists);

        await _context.SaveChangesAsync();
    }

    public Task<string> Login(LoginDTO dto)
    {
        throw new NotImplementedException();
    }

    private async Task<User?> FindUser(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email); 
    }
    
}