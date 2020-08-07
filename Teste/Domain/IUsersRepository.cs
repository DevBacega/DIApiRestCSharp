using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Domain
{
    public interface IUsersRepository
    {
        public Users Create(Users newUsers);
        public bool Delete(int Id_User);
        public bool Disable(int Id_User);
        public List<Users> Select(Users newUsers);
        public Users Update(Users newUsers);
    }
}
