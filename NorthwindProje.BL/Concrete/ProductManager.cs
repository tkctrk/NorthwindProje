using NorthwindProje.BL.Abstract;
using NorthwindProje.DAL.Abstract;
using NorthwindProje.DAL.Concrete;
using NorthwindProje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProje.BL.Concrete
{
    public class ProductManager : IGeneralService<Product>
    {
        private IGeneralRepository<Product> _productRepository;

        public ProductManager()
        {
            _productRepository = new ProductRepository();
        }
        public ProductManager(IGeneralRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Create(Product entity)
        {
            return _productRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public List<Product> GetAllT()
        {
            return _productRepository.GetAllT();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> Serch(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.Serch(expression);
        }

        public Product Single(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.Single(expression);
        }

        public Product Update(Product entity)
        {
            return _productRepository.Update(entity);
        }
    }
}
