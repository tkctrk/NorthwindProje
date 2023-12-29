using NorthwindProje.DAL.Abstract;
using NorthwindProje.DAL.SingleTon;
using NorthwindProje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProje.DAL.Concrete
{
    public class CategoryRepository : IGeneralRepository<Category>
    {
        private readonly NorthwindEnglishContext db;
        public CategoryRepository()
        {
            db = DbSingleTon.GetInstance();
        }

        public CategoryRepository(NorthwindEnglishContext db)
        {
            this.db = db;
        }
        public Category Create(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Categories.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Category> GetAllT()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return db.Categories.Where(x => x.CategoryId == id).First();
        }

        public List<Category> Serch(Expression<Func<Category, bool>> expression)
        {
            return db.Categories.Where(expression).ToList();

        }
        public Category Single(Expression<Func<Category, bool>> expression)
        {
            return db.Categories.Where(expression).First();
        }

        public Category Update(Category entity)
        {
            
           db.Categories.Update(entity);            
            db.SaveChanges();
            return entity;
        }
    }
}
