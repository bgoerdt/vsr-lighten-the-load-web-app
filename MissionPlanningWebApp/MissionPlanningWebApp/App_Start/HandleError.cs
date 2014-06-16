using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MissionPlanningWebApp.Controllers;

namespace MissionPlanningWebApp.App_Start
{
	public class HandleAndLogErrorAttribute : HandleErrorAttribute
	{

		public override void OnException(ExceptionContext filterContext)
		{
			var message = string.Format("Exception     : {0}\n" +
										"InnerException: {1}",
										filterContext.Exception,
										filterContext.Exception.InnerException);
			
			//base.OnException(filterContext);

		}
	}
}