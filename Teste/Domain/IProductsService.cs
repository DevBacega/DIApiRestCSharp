using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Models;

namespace Teste.Domain
{
    public interface IProductsService
    {
        public Products Create(Products newProducts);
        public bool Delete(int Id_User, bool Admin);
        public List<Products> Select(Products newProducts);
        public Products Update(Products newProducts);
    }
}

