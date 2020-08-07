using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Domain
{
    public interface IUsersService
    {
        public Users Create(Users request);
        public bool Delete(int Id_User, bool IsAdmin);
        public List<Users> Select(Users request);
        public Users Update(Users request);
    }
}
