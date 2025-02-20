using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class GoalRepository : RepositoryBase<Goal>
{
    public GoalRepository(HyciteDbContext context) : base(context)
    {
    }
}