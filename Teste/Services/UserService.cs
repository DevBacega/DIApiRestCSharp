using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain;
using Teste.Models;
using Teste.Repository;

namespace Teste.Services
{
    public class UserService : IUsersService
    {
        private IUsersRepository _userRepository;
        public UserService(IUsersRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Users Create(Users newUser)
        {
            return _userRepository.Create(newUser);
        }

        public Users Update(Users newUser)
        {
            return _userRepository.Update(newUser);
        }

        public bool Delete(int Id_User, bool Admin)
        {

            bool response =  Admin == true ? _userRepository.Delete(Id_User) : _userRepository.Disable(Id_User);
            return response == true ? true : throw new Exception("Usuario não existe.");
        }

        public List<Users> Select(Users newUser = null)
        {
            return _userRepository.Select(newUser);
        }
    }
}
