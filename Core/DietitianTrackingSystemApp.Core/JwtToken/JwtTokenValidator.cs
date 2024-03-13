using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DietitianTrackingSystemApp.Core.JwtToken
{
    public static class JwtTokenValidator
    {
        private static string tokenSecretKey = "";

        /// <summary>
        /// Access token validation işlemi.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="secretKey"></param>
        /// <param name="claimsPrincipal"></param>
        /// <returns></returns>
        public static bool AuthenticateAccessToken(string token, string secretKey, out ClaimsPrincipal claimsPrincipal)
        {
            tokenSecretKey = secretKey;

            return ValidateToken(token, out claimsPrincipal);
        }

        /// <summary>
        /// Refresh token validation işlemi.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="secretKey"></param>
        /// <param name="claimsPrincipal"></param>
        /// <returns></returns>
        public static bool AuthenticateRefreshToken(string token, string secretKey, out ClaimsPrincipal claimsPrincipal)
        {
            tokenSecretKey = secretKey;

            return ValidateToken(token, out claimsPrincipal);
        }

        public static IEnumerable<Claim> GetClaims(string token)
        {
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                    if (jwtToken == null)
                        return null;

                    return jwtToken.Claims;
                }
            }

            catch (Exception ex)
            {
            }

            return null;
        }

        private static bool ValidateToken(string token, out ClaimsPrincipal claimsPrincipal)
        {
            claimsPrincipal = null;

            var simplePrinciple = GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            claimsPrincipal = simplePrinciple;

            return true;
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(tokenSecretKey);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

                return principal;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}