using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOS.DashboardDTO
{
	public class ItemCountsDTO
	{
		public int CategoryCount { get; set; }	

		public int ProductCount { get; set; }

		public int ReservationCount { get; set; }	

		public int UnreadMessageCount { get; set; }
	}
}
