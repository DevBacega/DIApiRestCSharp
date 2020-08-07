using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{
    public class Auth
    {
        public int? Id_User { get; set; }
        public string Nm_User { get; set; }
        public string Ps_user { get; set; }
        public int? Id_Access { get; set; }
        public string Token { get; set; }
    }
}
