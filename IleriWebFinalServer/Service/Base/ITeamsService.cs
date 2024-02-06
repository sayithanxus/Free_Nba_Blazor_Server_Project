using Free_Nba_Blazor_Server_Project.Model;

namespace Free_Nba_Blazor_Server_Project.Service.Base
{
	public interface ITeamsService
	{
		Task<List<Teams>> GetAllTeamsAsync(string searchTerm);
        Task<Teams> GetSpecificTeam(int id);

    }
}
