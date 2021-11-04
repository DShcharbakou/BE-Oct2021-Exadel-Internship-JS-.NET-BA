using BLL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService : ITokenService
    {
        private IMemoryCache _cache;
        private const string TokensKey = "token_";
        private const int ExpirationInMinutes = 30;

        public TokenService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public bool IsBlacklisted(string token)
        {
            return _cache.Get(TokensKey + token) != null;
        }

        public void Login(string token)
        {
            throw new NotImplementedException();
        }

        public void Logout(string token)
        {
            _cache.Set(TokensKey + token, 1, TimeSpan.FromMinutes(ExpirationInMinutes + 1));
        }

        public DateTime? GetExpiryTime()
        {
            return DateTime.Now.AddMinutes(ExpirationInMinutes);
        }
    }
}
