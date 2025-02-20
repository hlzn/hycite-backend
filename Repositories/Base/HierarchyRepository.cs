using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class HierarchyRepository : RepositoryBase<Hierarchy>
{
    public HierarchyRepository(HyciteDbContext context) : base(context)
    {
    }
}