using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class UserSecurityRepository : RepositoryBase<UserSecurity>
{
    public UserSecurityRepository(HyciteDbContext context) : base(context)
    {
    }
}