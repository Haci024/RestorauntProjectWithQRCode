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
    public class TestimonialMananger : ITestimonialService
    {
        private readonly ITestimonialDAL _dal;
        public TestimonialMananger(ITestimonialDAL dal)
        {
            _dal= dal;  
        }
        public void Create(Testimonial entity)
        {
            _dal.Add(entity);
        }

        public void Delete(Testimonial entity)
        {
           _dal.Delete(entity);
        }

        public Testimonial GetById(int id)
        {
           return _dal.GetById(id);
        }

        public IEnumerable<Testimonial> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Testimonial entity)
        {
           _dal.Update(entity);
        }
    }
}
