using DietitianTrackingSystemApp.Core.JwtToken.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DietitianTrackingSystemApp.Core.JwtToken
{
    public static class JwtTokenGenerator
    {
        /// <summary>
        /// JWT token oluşturur.
        /// </summary>
        /// <param name="claimDatas">Token içinde saklanacak datalar</param>
        /// <param name="accessTokenSecret">Access token oluşturulurken kullanılacak secret key</param>
        /// <param name="expireDate">Access token'ın son kullanım zamanı</param>
        /// <param name="refreshExpireDate">Refresh token'ın son kullanım zamanı.</param>
        /// <param name="refreshTokenSecret">Refresh token oluşturulurken kullanılacak secret key. Bu data girilirse claimDatas değerleri refresh token içinde de saklanır ve refresh işlemlerinde db ye gitmeye gerek kalmaz.</param>
        /// <returns></returns>
        public static JWTResultModel GenerateToken(Dictionary<string, string> claimDatas, string accessTokenSecret, DateTime expireDate, string refreshTokenSecret = "", DateTime? refreshExpireDate = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimDatas != null ? new ClaimsIdentity(claimDatas.Select(x => new Claim(x.Key, x.Value))) : new ClaimsIdentity(),
                Expires = expireDate,
                //Sistemde loadbalancer varsa server saatlerinin uyumsuz olma durumuna karşı token başlangıç süresi 5 dk erken setleniyor.
                NotBefore = DateTime.UtcNow.AddMinutes(-5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(accessTokenSecret)), SecurityAlgorithms.HmacSha512Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return new JWTResultModel
            {
                AccessToken = tokenHandler.WriteToken(securityToken),
                RefreshToken = !string.IsNullOrEmpty(refreshTokenSecret) ? GenerateRefreshToken(claimDatas, refreshTokenSecret, refreshExpireDate.HasValue ? refreshExpireDate : (DateTime?)null) : GenerateRefreshToken()
            };
        }

        private static string GenerateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        private static string GenerateRefreshToken(Dictionary<string, string> claimDatas, string refreshTokenSecret, DateTime? expireDate = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimDatas.Select(x => new Claim(x.Key, x.Value))),
                Expires = expireDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Convert.FromBase64String(refreshTokenSecret)), SecurityAlgorithms.HmacSha512Signature)
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// Use the below code to generate symmetric Secret Key
        /// </summary>
        /// <returns></returns>
        private static string GenerateSymmetricKey()
        {
            var hmac = new HMACSHA256();

            return Convert.ToBase64String(hmac.Key);
        }
    }
}