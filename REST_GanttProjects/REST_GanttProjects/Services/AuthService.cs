using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthCore.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using REST_GanttProjects.Controllers;
using AuthenticateService;

namespace AuthCore.Services;

public class AuthService
{
    #region GenerateToken
    /// <summary>
    /// Gerar um token.
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Devolve um token de acesso</returns>
    public static string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AuthSettings.PrivateKey);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        // Criar o token com base nos dados do usuário
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = credentials,
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }
    #endregion

    #region GenerateClaims
    /// <summary>
    /// Definir perfis.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Name, user.name));
        claims.AddClaim(new Claim(ClaimTypes.Email, user.email));
        claims.AddClaim(new Claim(ClaimTypes.Role, user.role));

        return claims;
    }
    #endregion

}