using Free_Nba_Blazor_Server_Project.Model;

namespace Free_Nba_Blazor_Server_Project.Service.Base
{
	public interface IPlayersService
	{
		Task<List<Players>> GetAllPlayersAsync(string search);
        Task<Players> GetSpecificPlayer(int id);
	}
}
