using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceSheduleSystem.Core.Interfaces;
using MaintenanceSheduleSystem.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MaintenanceSheduleSystem.Core.Enums;
using Microsoft.IdentityModel.Tokens;
using MaintenanceSheduleSystem.Infrastructure.OutsideServiceOptions;
using Microsoft.Extensions.Options;

namespace MaintenanceSheduleSystem.Infrastructure.LogicServices
{
    public class JwtProviderService : IJwtProviderService
    {
        private readonly JwtOptions _options;

        public JwtProviderService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = [
                new("userId", user.Id.ToString()),

            ];
            var singningCredentinals = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: singningCredentinals,
                expires: DateTime.UtcNow.AddHours(_options.ExpitesHours));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }



}
