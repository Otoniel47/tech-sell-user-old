using Microsoft.Extensions.Options;
using Tech_sell_user.Application.Interfaces;
using Tech_sell_user.Database.Interface;

namespace Tech_sell_user.Application.Services
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        public readonly AppSettings _options;
        protected readonly IDateTimeService _dateTimeService;

        public BaseService(IUnitOfWork unitOfWork, IOptions<AppSettings> options, IDateTimeService dateTimeService)
        {
            _unitOfWork = unitOfWork;
            _options = options.Value;
            _dateTimeService = dateTimeService;
        }

        public DateTime GetDateTime() => _dateTimeService.GetDateTime();
    }
}