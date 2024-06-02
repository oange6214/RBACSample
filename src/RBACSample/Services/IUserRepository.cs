using RBACSample.Entities;

namespace RBACSample.Services;

public interface IUserRepository
{
    Task<TbLoginrole> GetUser(TbLoginrole user);
}