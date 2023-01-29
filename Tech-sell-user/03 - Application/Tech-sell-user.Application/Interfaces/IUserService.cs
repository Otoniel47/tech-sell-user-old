using System.Linq.Expressions;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmailAsync(string email);

        User GetUser(Expression<Func<User, bool>> predicate, string[] expands = null, bool withTracking = false);

        Task SaveAsync(User user);

        Task UpdateUserAsync(User user);
    }
}