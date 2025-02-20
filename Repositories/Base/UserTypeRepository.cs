using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class UserTypeRepository : RepositoryBase<UserType>
{
    public UserTypeRepository(HyciteDbContext context) : base(context)
    {
    }
}