using Annuaire_Bloc_4_API.Models;
using System.Collections.Generic;

namespace Annuaire_Bloc_4_API.Data
{
	public class MockApiRepo : IApiRepo
	{
		public IEnumerable<Site> GetAllSites()
		{
			var siteList = new List<Site>
			{
				new Site { Id = 1, City = "Marseille"},
				new Site { Id = 2, City = "Paris"},
				new Site { Id = 3, City = "Avignon"}
			};
			return siteList;
		}

		public Site GetSiteById(long id)
		{
			return new Site { Id = 1, City = "Marseille"};
		}
	}
}