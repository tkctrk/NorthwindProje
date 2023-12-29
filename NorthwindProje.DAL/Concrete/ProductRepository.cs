using Microsoft.EntityFrameworkCore;
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
    public class ProductRepository : IGeneralRepository<Product>
    {
        private readonly NorthwindEnglishContext db;
        public ProductRepository()
        {
            db = DbSingleTon.GetInstance();
        }

        public ProductRepository(NorthwindEnglishContext db)
        {
            this.db = db;
        }
        public Product Create(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            db.Products.Remove(GetById(id));
        }

        public List<Product> GetAllT()
        {
           return db.Products.Include(x=>x.Category).Include(x=>x.Supplier).ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.Where(x => x.ProductId == id).First();
        }

        public List<Product> Serch(Expression<Func<Product, bool>> expression)
        {
            return db.Products.Where(expression).ToList();
        }

        public Product Single(Expression<Func<Product, bool>> expression)
        {
            return db.Products.Where(expression).First();
        }

        public Product Update(Product entity)
        {
           var kayit=db.Products.Where(x=>x.ProductId==entity.ProductId).FirstOrDefault();
            kayit.ProductName=entity.ProductName;
            kayit.UnitPrice=entity.UnitPrice;
            kayit.UnitsInStock=entity.UnitsInStock;
            kayit.QuantityPerUnit=entity.QuantityPerUnit;
            db.SaveChanges();
            return entity;
        }
    }
}
