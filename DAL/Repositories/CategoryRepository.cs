using DAL.Abstract;
using DAL.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryDAL
    {
        public CategoryRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
