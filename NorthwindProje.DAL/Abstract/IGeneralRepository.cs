using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProje.DAL.Abstract
{
    public interface IGeneralRepository <T> where T : class
    {    
        List<T> GetAllT();
        void Delete(int id);
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        List<T> Serch(Expression<Func<T, bool>> expression);//BÜTÜN LİSTELERİ GETIRMEK ISTEMDIGIMIZ ZAMAN BUNU KULLANABILIRIZ.
        T Single(Expression<Func<T, bool>> expression);//TEK BİR KAYIT DÖNUCEK ISE YAPIYORUZ.
    }
}
