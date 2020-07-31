using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CedroTechApi.Utils
{
    public class TokenUtils
    {
        public static string CreateToken()
        {
            try
            {
                string secureKey = "Cedro_Secure_Key";
                var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
                var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

                var userJwt = new JwtSecurityToken(
                                    issuer: "CedroTech",
                                    expires: DateTime.Now.AddMinutes(3),
                                    audience: "BTG Pactual",
                                    signingCredentials: credentials
                                  );
                return new JwtSecurityTokenHandler().WriteToken(userJwt);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool TokenValid()
        {
            return true;
        }
    }
}
