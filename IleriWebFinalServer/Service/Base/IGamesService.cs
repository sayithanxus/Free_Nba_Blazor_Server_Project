using WEBUI.Model;

namespace WEBUI.Service.Base
{
	public interface IGamesService
	{
		Task<List<Games>> GetAllGamesAsync(int team_ids, int Seasons);
        Task<Games> GetSpecificGame(int id);
	}
}
