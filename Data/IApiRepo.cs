using Annuaire_Bloc_4_API.Models;
using System.Collections.Generic;

namespace Annuaire_Bloc_4_API.Data
{
	public interface IApiRepo
	{
		bool SaveChanges();

		#region Sites
		IEnumerable<Site> GetAllSites();
		Site GetSiteById(int id);
		void CreateSite(Site site);
		void UpdateSite(Site site);
		void DeleteSite(Site site);
		#endregion

		#region Services
		IEnumerable<Service> GetAllServices();
		Service GetServiceById(int id);
		void CreateService(Service service);
		void UpdateService(Service service);
		void DeleteService(Service service);
		#endregion
	}
}