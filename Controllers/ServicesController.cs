using Annuaire_Bloc_4_API.Data;
using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Annuaire_Bloc_4_API.Controllers
{
	[Route("api/services")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IApiRepo _repository;
		private readonly IMapper _mapper;

		public ServicesController(IApiRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		// GET api/services
		[HttpGet]
		public ActionResult<IEnumerable<ServiceReadDto>> GetAllServices()
		{
			var serviceList = _repository.GetAllServices();
			return Ok(_mapper.Map<IEnumerable<ServiceReadDto>>(serviceList));
		}

		// GET api/services/{id}
		[HttpGet("{id}", Name = "GetServiceById")]
		public ActionResult<ServiceReadDto> GetServiceById(int id)
		{
			var services = _repository.GetServiceById(id);
			return services != null? Ok(_mapper.Map<ServiceReadDto>(services)) : NotFound();
		}

		//POST api/services
		[HttpPost]
		public ActionResult<ServiceReadDto> CreateService(ServiceCreateDto serviceCreateDto)
		{
			// TODO check if infos are valid
			var serviceModel = _mapper.Map<Service>(serviceCreateDto);
			_repository.CreateService(serviceModel);
			_repository.SaveChanges();
			var serviceReadDto = _mapper.Map<ServiceReadDto>(serviceModel);

			return CreatedAtRoute(nameof(GetServiceById), new { Id = serviceReadDto.Id }, serviceReadDto);
		}

		// PUT api/services/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateService(int id, ServiceUpdateDto serviceUpdateDto)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var service = _repository.GetServiceById(id);
			if (service == null)
				return NotFound();
			_mapper.Map(serviceUpdateDto, service);
			_repository.UpdateService(service);
			_repository.SaveChanges();
			return NoContent();
		}

		// PATCH api/services/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<ServiceUpdateDto> patchDocument)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var service = _repository.GetServiceById(id);
			if (service == null)
				return NotFound();
			var commandToPatch = _mapper.Map<ServiceUpdateDto>(service);
			patchDocument.ApplyTo(commandToPatch, ModelState);
			if (!TryValidateModel(commandToPatch))
				return ValidationProblem(ModelState);
			_mapper.Map(commandToPatch, service);
			_repository.UpdateService(service);
			_repository.SaveChanges();
			return NoContent();
		}

		// DELETE api/services/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			var service = _repository.GetServiceById(id);
			if (service == null)
				return NotFound();
			_repository.DeleteService(service);
			_repository.SaveChanges();
			return NoContent();
		}
	}
}