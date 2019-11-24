using GestionPolizas.Common;
using GestionPolizas.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestionPolizas
{
    public class TokenProvider
    {
        public string LoginUser(string UserId, string Password)
        {
            var user = UserList.SingleOrDefault(x => x.UserId == UserId);
            if (user == null)
                return null;

            if (Password == user.Password)
            {
                //Authentication successful, Issue Token with user credentials - JRozario
                //Provide the security key which was given in the JWToken configuration in Startup.cs - JRozario
                var key = Encoding.ASCII.GetBytes("WQW79-OFFKDI940NG7-56753253-SADVF-5769-0921-DSD987987SA");
                //Generate Token for user - JRozario
                var JWToken = new JwtSecurityToken(
                    issuer: "http://localhost:45092/",
                    audience: "http://localhost:45092/",
                    claims: GetUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    //Using HS256 Algorithm to encrypt Token - JRozario
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }

        private List<User> UserList = new List<User>
        {
            new User { UserId = "Director", Password = "test", Email = "director@email.com", Name = "Director Prueba", Role = Roles.DIRECTOR, HaveAccess = "true" },
            new User { UserId = "Supervisor", Password = "test", Email = "supervisor@email.com", Name = "Supervisor Prueba", Role = Roles.SUPERVISOR, HaveAccess = "false" }
        };

        private IEnumerable<Claim> GetUserClaims(User user)
        {
            List<Claim> claims = new List<Claim>();
            Claim claim;
            claim = new Claim(ClaimTypes.Name, user.Name);
            claims.Add(claim);
            claim = new Claim("USERID", user.UserId);
            claims.Add(claim);
            claim = new Claim("EMAILID", user.Email);
            claims.Add(claim);
            claim = new Claim("ROLE", user.Role);
            claims.Add(claim);

            if (user.HaveAccess == "true")
            {
                claim = new Claim("HAVE_ACCESS", user.HaveAccess);
                claims.Add(claim);
            }

            return claims.AsEnumerable<Claim>();
        }
    }
}
