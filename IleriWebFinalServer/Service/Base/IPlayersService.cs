using WEBUI.Model;

namespace WEBUI.Service.Base
{
	public interface IPlayersService
	{
		Task<List<Players>> GetAllPlayersAsync(string search);
        Task<Players> GetSpecificPlayer(int id);
	}
}
