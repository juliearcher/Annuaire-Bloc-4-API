using Annuaire_Bloc_4_API.Data;
using Annuaire_Bloc_4_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Annuaire_Bloc_4_API.Controllers
{
	[Route("api/sites")]
	[ApiController]
	public class SitesController : ControllerBase
	{
		private readonly IApiRepo _repository;

		public SitesController(IApiRepo repository)
		{
			_repository = repository;
		}

		// GET api/sites
		[HttpGet]
		public ActionResult<IEnumerable<Site>>	GetAllSites()
		{
			var siteList = _repository.GetAllSites();
			return Ok(siteList);
		}

		// GET api/sites/{id}
		[HttpGet("{id}")]
		public ActionResult<IEnumerable<Site>> GetSiteById(long id)
		{
			var site = _repository.GetSiteById(id);
			return Ok(site);
		}
	}
}