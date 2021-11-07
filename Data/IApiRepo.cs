using Annuaire_Bloc_4_API.Models;
using System.Collections.Generic;

namespace Annuaire_Bloc_4_API.Data
{
	public interface IApiRepo
	{
		IEnumerable<Site> GetAllSites();
		Site GetSiteById(int id);
	}
}