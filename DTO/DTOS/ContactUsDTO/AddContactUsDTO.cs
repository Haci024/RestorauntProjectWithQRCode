using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ContactUsDTO
{
    public class AddContactUsDTO
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }
    }
}
