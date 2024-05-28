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
    public class OffersManager:IOffersService
    {
        private readonly IOffersDAL _dal;
        public OffersManager(IOffersDAL dal)
        {
            _dal= dal;
        }

        public void Create(Offers entity)
        {
            _dal.Add(entity);
        }

        public void Delete(Offers entity)
        {
            _dal.Delete(entity);
        }

        public Offers GetById(int id)
        {
           return _dal.GetById(id);
        }

        public List<Offers> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Offers entity)
        {
           _dal.Update(entity);
        }
    }
}
