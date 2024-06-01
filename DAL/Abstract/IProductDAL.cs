using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IProductDAL:IGenericDAL<Products>
    {
        public ICollection<Products> ProductListByCategory(int CategoryId);

        public ICollection<Products> ProductListWithCategory();
    }
}
