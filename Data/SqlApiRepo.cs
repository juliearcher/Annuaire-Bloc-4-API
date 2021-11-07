using Annuaire_Bloc_4_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire_Bloc_4_API.Data
{
	public class SqlApiRepo : IApiRepo
	{
		private readonly ApiContext _context;

		public SqlApiRepo(ApiContext context)
		{
			_context = context;
		}

		public IEnumerable<Site> GetAllSites()
		{
			return _context.Sites.ToList();
		}

		public Site GetSiteById(int id)
		{
			return _context.Sites.FirstOrDefault(p => p.Id == id);
		}
	}
}