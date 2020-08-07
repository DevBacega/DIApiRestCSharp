using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Teste.Domain;
using Teste.Models;
using Teste.Repository;

namespace Teste.Services
{
    public class AccessService : IAccessService
    {
        private IAccessRepository _AccessRepository;
        public AccessService(IAccessRepository accesRepository)
        {
            this._AccessRepository = accesRepository;
        }

        public Access Create(Access request)
        {
            return _AccessRepository.Create(request);
        }

        public Access Update(Access request)
        {
            return _AccessRepository.Update(request);
        }

        public bool Delete(int Id_User)
        {
                if (_AccessRepository.Delete(Id_User) == true)
                {
                    return true;
                }
                else
                {
                    throw new Exception("O cargo não existe.");
                }
        }

        public List<Access> Select(Access request = null)
        {
            return _AccessRepository.Select(request);
        }

    }
}
