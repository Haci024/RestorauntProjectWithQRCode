﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IProductService:IGenericService<Products>
    {
        public ICollection<Products> ProductListByCategory(int categoryId);
    }
}
