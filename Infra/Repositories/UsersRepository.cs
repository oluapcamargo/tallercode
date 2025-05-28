using CodeInterview.Domain.Entity;
using CodeInterview.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CodeInterview.Infra.Repositories;

public class UsersRepository
{
    private readonly AppDbContext _context;

    public UsersRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(Users user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Users>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<List<Users>> GetUsersByNameAsync(string username)
    {
        return await _context.Users.Where(t => t.Name.Contains(username)).ToListAsync();
    }
    public async Task<Users> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
}
