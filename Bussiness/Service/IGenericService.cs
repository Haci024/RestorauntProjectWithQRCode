using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IGenericService<T> where T : class
    {
      public  void Create(T entity);
       public void Update(T entity);
       public void Delete(T entity);
       public T GetById(int id);
      public  List<T> GetList();
    }
}
