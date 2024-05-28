using DAL.Abstract;
using DAL.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OfferRepository:GenericRepository<Offers>,IOffersDAL
    {
        public OfferRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
