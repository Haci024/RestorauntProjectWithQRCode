using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Abstract
{
    public interface IGenericDAL<T> where T : class 
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        T GetById(int id);

        IEnumerable<T> GetList();


    }
}
