using Hycite.Data;
using Hycite.Models;

namespace Hycite.Repositories;

public class CompanyRepository : RepositoryBase<Company>
{
    public CompanyRepository(HyciteDbContext context) : base(context)
    {
    }
}