namespace Free_Nba_Blazor_Server_Project.Model
{
	public class Stats
	{
		public int id { get; set; }
		public string ast { get; set; }
		public string blk { get; set; }
		public string dreb { get; set; }
		public string fg3_pct { get; set; }
		public string fg3a { get; set; }
		public string fg3m { get; set; }
		public string fg_pct { get; set; }
		public string fga { get; set; }
		public string fgm { get; set; }
		public string ft_pct { get; set; }
		public string fta { get; set; }
		public string ftm { get; set; }
		public string min { get; set; }
		public string oreb { get; set; }
		public string pf { get; set; }
		public string pts { get; set; }
		public string reb { get; set; }
		public string stl { get; set; }
        public Games game { get; set; }
        public Players player { get; set; }
        public Teams team { get; set; }
		public bool IsVisible { get; set; } = false;

    }
}
