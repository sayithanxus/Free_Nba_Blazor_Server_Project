using WEBUI.Model;

namespace WEBUI.Service.Base
{
	public interface IStatsService
	{
		Task<List<Stats>> GetAllStatsAsync();
	}
}
