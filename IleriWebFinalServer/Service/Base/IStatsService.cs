using Free_Nba_Blazor_Server_Project.Model;

namespace Free_Nba_Blazor_Server_Project.Service.Base
{
	public interface IStatsService
	{
		Task<List<Stats>> GetAllStatsAsync();
	}
}
