using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Areas.Admin.DTOS.ProductDTO
{
    public class GetProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }    

        public decimal Price { get; set; }  

        public string description { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }
    }
}
