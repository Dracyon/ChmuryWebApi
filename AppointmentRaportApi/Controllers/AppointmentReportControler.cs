using AppoitmentWebApp.Core;
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
	[Route("appointmentreport")]
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
		public List<AppointmentReport> Get()
		{
			var allAppointments = appointmentData.GetAppointmentByName(string.Empty);

			var onlyMarkedAppointments = allAppointments.
				Where(a => a.IsAvaiable == false && !string.IsNullOrEmpty(a.UserName)).ToList();

			var ReportData = new List<AppointmentReport>();

			foreach (var appointment in onlyMarkedAppointments)
			{
				ReportData.Add(new AppointmentReport
				{
					AppointmentName = appointment.AppointmentName,
					AppointmentDate = appointment.AppointmentDate,
					AppointedPerson = appointment.UserName
				});
			}

			return ReportData;
		}
	}
}
