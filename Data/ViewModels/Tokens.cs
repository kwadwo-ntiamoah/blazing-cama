using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class TokenModel {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
