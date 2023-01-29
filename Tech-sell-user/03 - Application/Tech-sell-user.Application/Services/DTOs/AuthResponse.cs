using Tech_sell_user.Application.Services.DTOs.Responses;

namespace Tech_sell_user.Application.DTOs
{
    public class AuthResponse: ResponseBase
    {
        public string Token { get; set; }

        public bool ConfirmedFirstAccess { get; set; }

        public string ResetToken { get; set; }

        public string PatientId { get; set; }
    }
}