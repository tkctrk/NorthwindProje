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
    public class CategoryManager : IGeneralService<Category>
    {
        private IGeneralRepository <Category> _categoryRepository;

        public CategoryManager()
        {
            _categoryRepository=new CategoryRepository();
        }
        public Category Create(Category entity)
        {
          return _categoryRepository.Create(entity);
            
        }

        public void Delete(int id)
        {
           _categoryRepository.Delete(id);
        }

        public List<Category> GetAllT()
        {
            return _categoryRepository.GetAllT();
        }

        public Category GetById(int id)
        {
          return _categoryRepository.GetById(id);
        }

        public List<Category> Serch(Expression<Func<Category, bool>> expression)
        {
           return _categoryRepository.Serch(expression);
        }

        public Category Single(Expression<Func<Category, bool>> expression)
        {
           return _categoryRepository.Single(expression);
        }

        public Category Update(Category entity)
        {
           return _categoryRepository.Update(entity);
        }
    }
}
