using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Domain
{
    public interface IAuth
    {
        public Auth Login(Auth request);
        public bool Authorization(string token);
        public bool IsAdmin(int Id_Access);
    }
}
