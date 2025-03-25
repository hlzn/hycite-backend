using Hycite.Data;
using Hycite.DTOs;
using Hycite.Models;

namespace Hycite.Repositories;

public interface IUserActivityRepository : IRepositoryBase<UserActivity>
{
}

public class UserActivityRepository : RepositoryBase<UserActivity>, IUserActivityRepository
{
    public UserActivityRepository(HyciteDbContext context) : base(context)
    {
    }
}