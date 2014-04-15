using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MissionPlanningWebApp.Models;

namespace MissionPlanningWebApp.Models
{
	public class MissionPlan
	{
		public Dictionary<Equipment, int> EquipmentList { get; set; }

		public void planMission()
		{
			_exportData();

			// call exe on server

			_getMissionResults();
		}

		private void _exportData()
		{
			// export equipment to file
			
			// export parameters to file

			// export mission rules to file
		}

		private void _getMissionResults()
		{
			// get results from MissionPlanning.txt and add to EquipmentList
		}
	}
}