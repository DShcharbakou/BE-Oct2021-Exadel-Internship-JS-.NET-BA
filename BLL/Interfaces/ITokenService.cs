using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITokenService
    {
        public void Login(string token);
        public void Logout(string token);
        public bool IsBlacklisted(string token);
        public DateTime? GetExpiryTime();
    }
}
