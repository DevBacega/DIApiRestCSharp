using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Teste.Domain;
using Teste.Models;
using Teste.Repository;

namespace Teste.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public Categories Create(Categories request)
        {
            return _categoryRepository.Create(request);
        }

        public Categories Update(Categories request)
        {
            return _categoryRepository.Update(request);
        }

        public bool Delete(int Id_User)
        {
                if(_categoryRepository.Delete(Id_User) == true)
                {
                    return true;
                }
                else
                {
                    throw new Exception("A catégoria não existe.");
                }
        }

        public List<Categories> Select(Categories request = null)
        {
            return _categoryRepository.Select(request);
        }
    }
}
