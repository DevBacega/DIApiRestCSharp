using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain;
using Teste.Models;
using Teste.Repository;

namespace Teste.Services
{
    public class AuthService: IAuth
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public Auth Login (Auth request)
        {
            try { 
            Users user = new Users()
            {
                Nm_User = request.Nm_User,
                Ps_User = request.Ps_user
            };

            user =  _userRepository.Select(user).First();

                Auth Auth = new Auth()
                {
                    Id_User = user.Id_User,
                    Nm_User = user.Nm_User,
                    Id_Access = user.Access.Id_Access,
                    Token = "UmaCriptografiaMuitoLocaAqui"
                };

            return Auth;
            } catch
            {
                throw new System.ArgumentException("Nome ou Senha errados.");
            }
        } 
        public bool Authorization(string token)
        {
            if(token == "UmaCriptografiaMuitoLocaAqui" )
            {
                return true;
            }
            else
            {
                throw new System.ArgumentException("Usuario não logado.");
            }
        }

        public bool IsAdmin(int Id_Access)
        {
            return Id_Access == 1 ? true : false;
        }
    }
}
