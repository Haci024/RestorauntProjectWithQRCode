﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public int CategoryId {  get; set; }    

        public string Description { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }

    }
}
