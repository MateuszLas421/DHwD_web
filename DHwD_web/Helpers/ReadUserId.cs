using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Helpers
{
    public static class ReadUserId
    {
        public async static Task<int> Read(HttpContext httpContext)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = httpContext.Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var identity = tokenS.Claims.First(claim => claim.Type == "jti").Value;
            return await Task.FromResult(int.Parse(identity));
        }
    }
}
