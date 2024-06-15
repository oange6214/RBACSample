using RBACSample.Domains.Entities;
using RBACSample.Infrastructures.Data;
using System.Data.Common;
using System.Net.Sockets;

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
        var isConnection = CheckDatabaseConnection();

        try
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(item => item.Username == username);

            return user;
        }
        catch (SocketException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (DbException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
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

    public bool CheckDatabaseConnection()
    {
        try
        {
            _dbContext.Database.CanConnect();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}