using Authorization.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Authorization.DataAccess;

public class AuthorizationRepository(AuthorizationContext context) : IAuthorizationRepository
{
    private readonly AuthorizationContext _context = context;

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity != null)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}