using RBACSample.Entities;

namespace RBACSample.Repository;

public interface IUserRepository
{
    Task<TbLoginrole> GetUserByUsername(string username);

    Task CreateUser(TbLoginrole user);
}