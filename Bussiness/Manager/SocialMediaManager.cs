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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDAL _dal;
        public SocialMediaManager(ISocialMediaDAL dal)
        {
            _dal = dal;
        }
        public void Create(SocialMedia entity)
        {
            _dal.Add(entity);
        }

        public void Delete(SocialMedia entity)
        {
            _dal.Delete(entity);
        }

        public SocialMedia GetById(int id)
        {
            return _dal.GetById(id);
        }

        public IEnumerable<SocialMedia> GetList()
        {
            return _dal.GetList();
        }

        public void Update(SocialMedia entity)
        {
            _dal.Update(entity);
        }
    }
}
