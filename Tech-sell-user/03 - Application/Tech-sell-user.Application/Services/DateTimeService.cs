using Microsoft.Extensions.Options;

namespace Tech_sell_user.Application.Services
{
    public class DateTimeService
    {
        private readonly int timeZone;

        public DateTimeService(IOptions<AppSettings> options)
        {
            timeZone = options.Value.TimeZone ?? -3;
        }

        public DateTime GetDateTime()
        {
            return DateTime.UtcNow.AddHours(timeZone);
        }
    }
}