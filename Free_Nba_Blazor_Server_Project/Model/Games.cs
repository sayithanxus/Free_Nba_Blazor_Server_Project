using Microsoft.AspNetCore.Components.Forms;
using System.Data.SqlTypes;

namespace Free_Nba_Blazor_Server_Project.Model
{
	public class Games
	{
        public int id { get; set; }
		public string abbreviation { get; set; }
		public int home_team_score { get; set; }
		public int period { get; set; }
		public int season { get; set; }
		public string status { get; set; }
		public Teams home_team { get; set; }
		public int home_team_id { get; set; }
		public Teams visitor_team { get; set; }
		public int visitor_team_id { get; set; }
		public string visitor_team_score { get; set; }
	}
}
