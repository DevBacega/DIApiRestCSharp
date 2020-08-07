using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{
    public class Users
    {

        public int? Id_User { get; set; } = null;
        public string Nm_User { get; set; } = null;
        public string Ps_User { get; set; } = null;
        public Access Access { get; set; } = new Access();
        public int? Active { get; set; } = null;
    }
}
