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
    public class FeaturesManager:IFeaturesService
    {
        private readonly IFeaturesDAL _dal;
        public FeaturesManager(IFeaturesDAL dal)
        {
            _dal= dal;  
        }

        public void Create(Features entity)
        {
            _dal.Add(entity);
        }

        public void Delete(Features entity)
        {
            _dal.Delete(entity);
        }

        public Features GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<Features> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Features entity)
        {
          _dal.Update(entity);  
        }
    }
}
