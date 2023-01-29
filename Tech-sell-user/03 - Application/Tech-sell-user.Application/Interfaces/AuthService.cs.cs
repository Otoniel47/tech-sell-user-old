using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tech_sell_user.Domain;

namespace Tech_sell_user.Application.Interfaces
{
    //public class AuthService : IAuthService
    //{
    //    //public string ScretKey { get; set; }
    //    //public string SecurityAlgorithm { get; set; }
    //    //public int ExpireMinutes { get; set; }
    //    //public Claim[] Claims { get; set; }

    //    //public AuthService(string secretKey)
    //    //{
    //    //    ScretKey = secretKey;
    //    //}

    //    //private SecurityKey GetSymmetricSecurityKey()
    //    //{
    //    //    byte[] symmetrickey = Convert.FromBase64String(ScretKey);
    //    //    return new SymmetricSecurityKey(symmetrickey);
    //    //}

    //    //private TokenValidationParameters GetTokenValidationParameters()
    //    //{
    //    //    return new TokenValidationParameters()
    //    //    {
    //    //        ValidateIssuer = false,
    //    //        ValidateAudience = false,
    //    //        IssuerSigningKey = GetSymmetricSecurityKey()
    //    //    };
    //    //}

    //    //public bool IsTokenValid(string token) 
    //    //{
    //    //    if (string.IsNullOrEmpty(token))
    //    //        throw new ArgumentNullException("Given token is null or empty.");

    //    //    TokenValidationParameters tokenvalidationParameters = GetTokenValidationParameters();

    //    //    JwtSecurityTokenHandler JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    //    //    try
    //    //    {
    //    //        ClaimsPrincipal tokenValid = JwtSecurityTokenHandler.ValidateToken(token, tokenvalidationParameters, out SecurityToken validatedToken);
    //    //        return true;
    //    //    }
    //    //    catch (Exception)
    //    //    {

    //    //        throw;
    //    //    }
    //    //}

    //    //public string GenerateToken(IAuthContainerService service)
    //    //{
    //    //    if (service == null || service.Claims == null || service.Claims.Length == 0)
    //    //        throw new ArgumentNullException("Arguments to create token are not valid.");

    //    //    SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
    //    //    {
    //    //        Subject = new ClaimsIdentity(service.Claims),
    //    //        Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(service.ExpireMinutes)),
    //    //        SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), service.SecurityAlgorithm)
    //    //    };

    //    //    JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    //    //    SecurityToken securityToken = wtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
    //    //    return;
    //    //}
    //}
}