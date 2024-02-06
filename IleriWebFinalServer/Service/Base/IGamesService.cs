using Free_Nba_Blazor_Server_Project.Model;

namespace Free_Nba_Blazor_Server_Project.Service.Base
{
	public interface IGamesService
	{
		Task<List<Games>> GetAllGamesAsync(int team_ids, int Seasons);
        Task<Games> GetSpecificGame(int id);
	}
}
