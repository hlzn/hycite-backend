using Hycite.Data;
using Hycite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Hycite.Repositories;

public interface IUserRepository : IRepositoryBase<User>
{
}

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(HyciteDbContext context) : base(context)
    {
    }
}