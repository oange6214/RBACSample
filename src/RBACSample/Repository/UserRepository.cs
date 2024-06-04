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

    public async Task<TbLoginrole> GetUserByUsername(string username)
    {
        return await _dbContext.TbLoginroles
                               .FirstOrDefaultAsync(item => item.Username == username);
    }

    public async Task CreateUser(TbLoginrole user)
    {
        user.Name = "NAME";
        user.Type = "TYPE";
        await _dbContext.TbLoginroles.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}