using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.ReservationDTO
{
    public class AddReservationDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int PersonCount { get; set; }

        public string Email { get; set; }

        public DateTime Date { get; set; }

    }
}
