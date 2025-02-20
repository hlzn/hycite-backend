using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class AccessLevelRepository : RepositoryBase<AccessLevel>
{
    public AccessLevelRepository(HyciteDbContext context) : base(context)
    {
    }
}