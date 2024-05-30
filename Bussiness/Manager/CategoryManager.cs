using Business.Services;
using DAL.Abstract;
using DAL.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _dal;
        public CategoryManager(ICategoryDAL context)
        {
            _dal = context;
        }
        public void Create(Category entity)
        {
            _dal.Add(entity);
        }

        public void Delete(Category entity)
        {
            _dal.Delete(entity);
        }

        public Category GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _dal.GetList();
        }
        
      
        public void Update(Category entity)
        {
            _dal.Update(entity);
        }
    }
}
