﻿using DAL.Abstract;
using DAL.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FeaturesRepository:GenericRepository<Features>,IFeaturesDAL
    {
        public FeaturesRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
