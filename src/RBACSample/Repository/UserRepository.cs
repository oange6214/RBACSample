using Microsoft.EntityFrameworkCore;
using RBACSample.Data;
using RBACSample.Entities;

namespace RBACSample.Repository;

public class UserRepository : IUserRepository
{
    private readonly RoleDbContext _dbContext;

    public UserRepository(RoleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TbLoginrole> GetUser(TbLoginrole user)
    {
        var result = await _dbContext.TbLoginroles
                                       .FirstOrDefaultAsync(item =>
                                           item.Username == user.Username && item.PasswordHash == user.PasswordHash);

        return result ?? null;
    }
}