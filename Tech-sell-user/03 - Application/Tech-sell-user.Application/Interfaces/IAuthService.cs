using Tech_sell_user.Application.DTOs;
using Tech_sell_user.Application.Services.DTOs.Request;

namespace Tech_sell_user.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(AuthRequest request);

        Task<AuthResponse> WebLoginAsync(AuthRequest request);
    }
}