using WEBUI.Model;

namespace WEBUI.Service.Base
{
	public interface ITeamsService
	{
		Task<List<Teams>> GetAllTeamsAsync(string searchTerm);
        Task<Teams> GetSpecificTeam(int id);

    }
}
