using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class UserActivityRepository : RepositoryBase<UserActivity>
{
    public UserActivityRepository(HyciteDbContext context) : base(context)
    {
    }
}