using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tech_sell_user.Application.DTOs;
using Tech_sell_user.Application.Interfaces;
using Tech_sell_user.Application.Services.DTOs.Request;
using Tech_sell_user.Domain.Entities;

namespace Tech_sell_user.Application
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly ITemplateService _templateService;
        private readonly IDateTimeService _dateTimeService;
        private readonly AppSettings _appSettings;

        private const string ServiceName = "ObstCare";

        public AuthService(
            IUserService userService,
            IOptions<AppSettings> options,
            IEmailService emailService,
            ITemplateService templateService,
            IDateTimeService dateTimeService)
        {
            _userService = userService;
            _emailService = emailService;
            _templateService = templateService;
            _dateTimeService = dateTimeService;
            _appSettings = options.Value;
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            try
            {
                var user = await _userService.GetByEmailAsync(request.Email.Trim());

                if (user.Email == default || user.Email == null)
                    return new AuthResponse { Message = "Usuário não cadastrado", Success = false };

                return AuthenticateUser(request, user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Private

        private static bool VerifyPassword(User user, string passworkFromRequest)
        {
            var passwordCalculated = System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passworkFromRequest,
                salt: Convert.FromBase64String(user.Salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)));

            return user.Password == passwordCalculated;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = GetClaims(user),
                Expires = DateTime.UtcNow.AddHours(_appSettings.TokenExpirationTimeInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity GetClaims(User user)
        {

            var claimsIdentity = new ClaimsIdentity();

            var dataAtual = _dateTimeService.GetDateTime();

            if (user.Email != null)
            {
                claimsIdentity.AddClaim(new Claim("userId", user.Id.ToString()));
                claimsIdentity.AddClaim(new Claim("userName", user.Name));
            }

            return claimsIdentity;
        }

        private AuthResponse AuthenticateUser(AuthRequest request, User? user)
        {
            if (user != default &&
                                VerifyPassword(user, request.Password) && user.EmailConfirmed)
            {
                var token = GenerateJwtToken(user);

                return new AuthResponse { Token = token, Message = "Logado com sucesso!", Success = true };
            }

            return new AuthResponse { Message = "Email ou senha inválida", Success = false };
        }

        public Task<AuthResponse> WebLoginAsync(AuthRequest request)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}