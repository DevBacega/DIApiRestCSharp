using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Domain
{
    public interface IAccessRepository
    {
        public Access Create(Access request);
        public List<Access> Select(Access request);
        public Access Update(Access request);
        public bool Delete(int Id_Access);


    }
}
