using RBACSample.Entities;

namespace RBACSample.Repository;

public interface IUserRepository
{
    Task<TbLoginrole> GetUser(TbLoginrole user);
}