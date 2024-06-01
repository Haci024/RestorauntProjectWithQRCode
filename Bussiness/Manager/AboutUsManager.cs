using Business.Service;
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
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutDAL _dal;
        public AboutUsManager(IAboutDAL dal)
        {

            _dal = dal;

        }
        public void Create(AboutUs entity)
        {
           
            _dal.Add(entity);
        }

        public void Delete(AboutUs entity)
        {
            _dal.Delete(entity);
        }

        public AboutUs GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<AboutUs> GetList()
        {
            return _dal.GetList();
        }

        public void Update(AboutUs entity)
        {
            _dal.Update(entity);
        }
    }
}
