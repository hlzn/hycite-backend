using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class UserRepository : RepositoryBase<User>
{
    public UserRepository(HyciteDbContext context) : base(context)
    {
    }
}