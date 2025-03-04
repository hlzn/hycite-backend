using Hycite.Data;
using Hycite.Models;
using Microsoft.EntityFrameworkCore;

namespace Hycite.Repositories;

public interface IUserSecurityRepository : IRepositoryBase<UserSecurity>
{
    Task<UserSecurity?> GetByEmailAsync(string email);
}

public class UserSecurityRepository : RepositoryBase<UserSecurity>, IUserSecurityRepository
{
    public UserSecurityRepository(HyciteDbContext context) : base(context)
    {
    }

    public async Task<UserSecurity?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
    }
}