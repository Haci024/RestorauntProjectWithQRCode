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
    public class ReservationManager:IReservationService
    {
        private readonly IReservationDAL _dal;
        public ReservationManager(IReservationDAL dal)
        {
            _dal = dal;
        }

        public void Create(Reservation entity)
        {
            _dal.Add(entity);
        }

        public void Delete(Reservation entity)
        {
            _dal.Delete(entity);
        }

        public Reservation GetById(int id)
        {
           return _dal.GetById(id);
        }

        public IEnumerable<Reservation> GetList()
        {
            return _dal.GetList();
        }

        public void Update(Reservation entity)
        {
            _dal.Update(entity);
        }
    }
}
