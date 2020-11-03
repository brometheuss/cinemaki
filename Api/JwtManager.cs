using Application.DataTransfer;
using Application.ICommands;
using Application.Interfaces;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class JwtManager
    {
        private readonly ILoginUserCommand loginUser;

        public JwtManager(ILoginUserCommand loginUser)
        {
            this.loginUser = loginUser;
        }

        public string MakeToken(LoginUserDto user)
        {
            var actordb = loginUser.Execute(user);

            var actor = new JwtActor
            {
                Id = actordb.Id,
                Identity = actordb.Username,
                AllowedUseCases = actordb.Cases
            };

            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(180),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

/*public class FakeApiActor : IApplicationActor
{
    public int Id => 1;
    public string Identity => "Test User";
    public IEnumerable<int> AllowedUseCases => new List<int> { 1 };
}*/
