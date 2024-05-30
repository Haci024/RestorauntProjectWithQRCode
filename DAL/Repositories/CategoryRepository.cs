using DAL.Abstract;
using DAL.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryDAL
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext context):base(context)
        {
            _db = context; 
        }

       
    }
}
