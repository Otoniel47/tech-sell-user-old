using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using Tech_sell_user.Application.Interfaces;
using Tech_sell_user.Database.Interface;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Application.Services
{
    public class UserService: BaseService,IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IOptions<AppSettings> options, IDateTimeService dateTimeService) : base(unitOfWork, options, dateTimeService)
        {
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return Task.FromResult(_unitOfWork.UserRepository.Query(expression: x => x.Email == email, new string[] { $"{nameof(User.Email)}" }).FirstOrDefault());
        }

        public User GetUser(Expression<Func<User, bool>> predicate, string[] expands = null, bool withTracking = false)
        {
            return _unitOfWork.UserRepository.Query(predicate, expands, withTracking).FirstOrDefault();
        }

        public async Task SaveAsync(User user)
        {
            user.CreateDdate = GetDateTime();

            await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            user.UpdateDate = GetDateTime();

            _unitOfWork.UserRepository.Update(user);

            await _unitOfWork.CommitAsync();
        }
    }
}