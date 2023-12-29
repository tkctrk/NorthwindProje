using NorthwindProje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProje.DAL.SingleTon
{
    public class DbSingleTon 
    {
        private static NorthwindEnglishContext instance = null;

        public static NorthwindEnglishContext GetInstance()
        {
            if (instance == null)
            {
                instance = new NorthwindEnglishContext();
            }
            return instance;
        }
    }
}
