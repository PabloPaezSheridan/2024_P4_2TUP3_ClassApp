using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService
    {
        public IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetProducts() 
        {
            return _repository.Get();
        }

        public void AddProduct(Product product)
        {
            _repository.Add(product);
        }
    }
}
