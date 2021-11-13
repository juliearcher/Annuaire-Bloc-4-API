using Annuaire_Bloc_4_API.Data;
using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire_Bloc_4_API.Controllers
{
	[Route("api/employees")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IApiRepo _repository;
		private readonly IMapper _mapper;

		public EmployeesController(IApiRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		// GET api/employees
		[HttpGet]
		public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
		{
			var employeeList = _repository.GetAllEmployees();
			var sitesList = _repository.GetAllSites();
			var servicesList = _repository.GetAllServices();
			var employeeReadDtoList = _mapper.Map<IEnumerable<EmployeeReadDto>>(employeeList);
			for (int i  = 0; i < employeeReadDtoList.Count() && i < employeeList.Count(); ++i)
			{
				var service = servicesList.Where(p => p.Id == employeeList.ElementAt(i).ServicesId).First();
				var site = sitesList.Where(p => p.Id == employeeList.ElementAt(i).SitesId).First();
				employeeReadDtoList.ElementAt(i).Site = site.City;
				employeeReadDtoList.ElementAt(i).Service = service.Name;
			}
			return Ok(employeeReadDtoList);
		}

		// GET api/employees/{id}
		[HttpGet("{id}", Name = "GetEmployeeById")]
		public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
		{
			var employee = _repository.GetEmployeeById(id);
			if (employee == null)
				return NotFound();
			var service = _repository.GetServiceById((int)employee.ServicesId);
			var site = _repository.GetSiteById((int)employee.SitesId);
			var employeeReadDto = _mapper.Map<EmployeeReadDto>(employee);
			employeeReadDto.Site = site.City;
			employeeReadDto.Service = service.Name;
			return Ok(employeeReadDto);
		}

		//POST api/employees
		[HttpPost]
		public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
		{
			// TODO check if infos are valid
			var employeeModel = _mapper.Map<Employee>(employeeCreateDto);
			_repository.CreateEmployee(employeeModel);
			_repository.SaveChanges();
			var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

			return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);
		}

		// PUT api/employees/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var employee = _repository.GetEmployeeById(id);
			if (employee == null)
				return NotFound();
			_mapper.Map(employeeUpdateDto, employee);
			_repository.UpdateEmployee(employee);
			_repository.SaveChanges();
			return NoContent();
		}

		// PATCH api/employees/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patchDocument)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var employee = _repository.GetEmployeeById(id);
			if (employee == null)
				return NotFound();
			var commandToPatch = _mapper.Map<EmployeeUpdateDto>(employee);
			patchDocument.ApplyTo(commandToPatch, ModelState);
			if (!TryValidateModel(commandToPatch))
				return ValidationProblem(ModelState);
			_mapper.Map(commandToPatch, employee);
			_repository.UpdateEmployee(employee);
			_repository.SaveChanges();
			return NoContent();
		}

		// DELETE api/employees/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			var employee = _repository.GetEmployeeById(id);
			if (employee == null)
				return NotFound();
			_repository.DeleteEmployee(employee);
			_repository.SaveChanges();
			return NoContent();
		}
	}
}