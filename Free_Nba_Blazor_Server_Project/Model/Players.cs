namespace Free_Nba_Blazor_Server_Project.Model
{
	public class Players
	{
        public int id { get; set; }
        public int? height_feet { get; set; }
        public int? height_inches { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string position { get; set; }
        public string weight_pounds { get; set; }
        public Teams team { get; set; }
        public int team_id { get; set; }
    }
}
