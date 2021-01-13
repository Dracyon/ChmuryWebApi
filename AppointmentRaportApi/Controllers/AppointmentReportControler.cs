using AppoitmentWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentRaportApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AppointmentReportControler : ControllerBase
	{
		private readonly ILogger<AppointmentReportControler> _logger;
		private readonly IAppointmentData appointmentData;

		public AppointmentReportControler(ILogger<AppointmentReportControler> logger, IAppointmentData appointmentData)
		{
			_logger = logger;
			this.appointmentData = appointmentData;
		}

		[HttpGet]
		public IEnumerable<IAppointmentData> Get()
		{
			var allAppointments = appointmentData.GetAppointmentByName(string.Empty);

			var onlyMarkedAppointments = allAppointments.
				Where(a => a.IsAvaiable == false && !string.IsNullOrEmpty(a.UserName));


			return (IEnumerable<IAppointmentData>)onlyMarkedAppointments;
		}
	}
}
