using Business.Service;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Manager
{
    public class ContactUsManager : IContactUsService
    {
        private readonly  IContactUsDAL _dal;
        public ContactUsManager(IContactUsDAL dal)
        {

            _dal = dal;

        }
        public void Create(ContactUs entity)
        {
            _dal.Add(entity);
        }

        public void Delete(ContactUs entity)
        {
            _dal.Delete(entity);
        }

        public ContactUs GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<ContactUs> GetList()
        {
           return _dal.GetList();
        }

        public void Update(ContactUs entity)
        {
            _dal.Update(entity);
        }
    }
}
