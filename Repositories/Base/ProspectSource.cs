using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class ProspectSourceRepository : RepositoryBase<ProspectSource>
{
    public ProspectSourceRepository(HyciteDbContext context) : base(context)
    {
    }
}