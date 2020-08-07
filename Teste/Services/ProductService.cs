using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain;
using Teste.Models;
using Teste.Repository;

namespace Teste.Services
{
    public class ProductService : IProductsService
    {
        private IProductRepository _ProductRepository;
        public ProductService(IProductRepository productRepository)
        {
            this._ProductRepository = productRepository;
        }

        public Products Create(Products request)
        {
            return _ProductRepository.Create(request);
        }

        public Products Update(Products request)
        {
            return _ProductRepository.Update(request);
        }

        public bool Delete(int Id_Product, bool Admin)
        {

            bool response = Admin == true ? _ProductRepository.Delete(Id_Product) : _ProductRepository.Disable(Id_Product);
            return response == true ? true : throw new Exception("Usuario não existe.");
        }

        public List<Products> Select(Products request = null)
        {
            return _ProductRepository.Select(request);
        }
    }
}
