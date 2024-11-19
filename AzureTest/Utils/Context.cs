using AzureTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureTest.Utils;

public class Context : Microsoft.EntityFrameworkCore.DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
}