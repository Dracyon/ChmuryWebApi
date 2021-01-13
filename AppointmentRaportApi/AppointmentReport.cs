using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentRaportApi
{
	public class AppointmentReport
	{
		public string AppointmentName { get; set; }
		public DateTime AppointmentDate { get; set; }
		public string AppointedPerson { get; set; }
	}
}
