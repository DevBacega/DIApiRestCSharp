using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Domain
{
    public interface ICategoryService
    {
        public Categories Create(Categories request);
        public bool Delete(int Id_Category);
        public List<Categories> Select(Categories request);
        public Categories Update(Categories request);
    }
}
