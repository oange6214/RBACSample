using RBACSample.Domains.Entities;
using RBACSample.Infrastructures.Data;

namespace RBACSample.Infrastructures.Repository;

public class UserRepository : Repository<UserEntity>, IUserRepository
{
    private readonly RoleDbContext _dbContext;

    public UserRepository(RoleDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserEntity?> GetUserByUsername(string username)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(item => item.Username == username);

        return user;
    }

    public async Task<UserEntity?> GetUserWithRoleAndResourcesByUsername(string username)
    {
        var user = await _dbContext.Users
            .Include(u => u.Role)
            .ThenInclude(r => r.RoleResources)
            .ThenInclude(rr => rr.Resource)
            .FirstOrDefaultAsync(item => item.Username == username);

        return user;
    }

    public async Task CreateUser(UserEntity user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}