using Annuaire_Bloc_4_API.Data;
using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Annuaire_Bloc_4_API.Controllers
{
	[Route("api/sites")]
	[ApiController]
	public class SitesController : ControllerBase
	{
		private readonly IApiRepo _repository;
		private readonly IMapper _mapper;

		public SitesController(IApiRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		// GET api/sites
		[HttpGet]
		public ActionResult<IEnumerable<SiteReadDto>>	GetAllSites()
		{
			var siteList = _repository.GetAllSites();
			return Ok(_mapper.Map<IEnumerable<SiteReadDto>>(siteList));
		}
	
		// GET api/sites/{id}
		[HttpGet("{id}", Name = "GetSiteById")]
		public ActionResult<Site> GetSiteById(int id)
		{
			var site = _repository.GetSiteById(id);
			return site != null ? Ok(site) : NotFound(); ;
			// Return all site
			//return site != null? Ok(_mapper.Map<SiteReadDto>(site)) : NotFound();
		}

		//POST api/sites
		[HttpPost]
		public ActionResult<SiteReadDto> CreateSite(SiteCreateDto siteCreateDto)
		{
			// TODO check if infos are valid
			var siteModel = _mapper.Map<Site>(siteCreateDto);
			_repository.CreateSite(siteModel);
			_repository.SaveChanges();
			var siteReadDto = _mapper.Map<SiteReadDto>(siteModel);

			return CreatedAtRoute(nameof(GetSiteById), new { Id = siteReadDto.Id}, siteReadDto);
		}

		// PUT api/sites/{id}
		[HttpPut("{id}")]
		public ActionResult	UpdateSite(int id, SiteUpdateDto siteUpdateDto)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var site = _repository.GetSiteById(id);
			if (site == null)
				return NotFound();
			_mapper.Map(siteUpdateDto, site);
			_repository.UpdateSite(site);
			_repository.SaveChanges();
			return NoContent();
		}

		// PATCH api/sites/{id}
		[HttpPatch("{id}")]
		public ActionResult	PartialCommandUpdate(int id, JsonPatchDocument<SiteUpdateDto> patchDocument)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var site = _repository.GetSiteById(id);
			if (site == null)
				return NotFound();
			var commandToPatch = _mapper.Map<SiteUpdateDto>(site);
			patchDocument.ApplyTo(commandToPatch, ModelState);
			if (!TryValidateModel(commandToPatch))
				return ValidationProblem(ModelState);
			_mapper.Map(commandToPatch, site);
			_repository.UpdateSite(site);
			_repository.SaveChanges();
			return NoContent();
		}

		// DELETE api/sites/{api}
		[HttpDelete("{id}")]
		public ActionResult	DeleteCommand(int id)
		{
			var site = _repository.GetSiteById(id);
			if (site == null)
				return NotFound();
			_repository.DeleteSite(site);
			_repository.SaveChanges();
			return NoContent();
		}
	}
}