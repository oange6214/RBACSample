using RBACSample.Domains.Entities;

namespace RBACSample.Infrastructures.Repository;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<UserEntity> GetUserByUsername(string username);

    Task CreateUser(UserEntity user);
}