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
    public class ProductRepository:GenericRepository<Products>,IProductDAL
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext context):base(context) {
        
            _db=context;
        }

        public ICollection<Products> ProductListByCategory(int CategoryId)
        {
            return _db.Products.Include(x=>x.Category).Where(x=>x.CategoryId==CategoryId && x.Status==true && x.Category.Status==true).ToList();
        }

		public ICollection<Products> ProductListWithCategory()
		{
			return _db.Products.Include(x => x.Category).Where(x =>x.Status == true && x.Category.Status == true).ToList();
		}
	}
}
