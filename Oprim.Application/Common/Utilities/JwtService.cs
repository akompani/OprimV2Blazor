using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Oprim.Application.Common.Utilities;

public class JwtService(IConfiguration _config)
{
    // public string GenerateToken(User user, IList<string> roles)
    // {
    //     var claims = new List<Claim>
    //     {
    //         new Claim(ClaimTypes.Name, user.UserName),
    //         new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //         new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? "")
    //     };
    //
    //     foreach (var role in roles)
    //     {
    //         claims.Add(new Claim(ClaimTypes.Role, role));
    //     }
    //
    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //
    //     var token = new JwtSecurityToken(
    //         issuer: _config["Jwt:Issuer"],
    //         audience: _config["Jwt:Audience"],
    //         claims: claims,
    //         expires: DateTime.UtcNow.AddYears(3),
    //         signingCredentials: creds
    //     );
    //
    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
}