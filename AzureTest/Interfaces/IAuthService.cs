using AzureTest.Entities;

namespace AzureTest.Interfaces;

public interface IAuthService
{
    string GenerateToken(User user);
    string HashPassword(string password);
    bool ComparePassword(string password, string hash);
}