using Business.Services;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL _dal;
        public ProductManager(IProductDAL dal)
        {
            _dal = dal;
        }
        public void Create(Products entity)
        {
            _dal.Add(entity);
        }

        public void Delete(Products entity)
        {
            _dal.Delete(entity);
        }

        public Products GetById(int id)
        {
            return _dal.GetById(id);    
        }

        public IEnumerable<Products> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Products entity)
        {
            _dal.Update(entity);
        }
        public ICollection<Products> ProductListByCategory(int categoryId)
        {

           return _dal.ProductListByCategory(categoryId);
        }

		public ICollection<Products> ProductListWithCategory()
		{
			throw new NotImplementedException();
		}
	}
}
