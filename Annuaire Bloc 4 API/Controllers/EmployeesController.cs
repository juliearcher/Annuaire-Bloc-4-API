using AnnuaireBloc4API.Data;
using AnnuaireBloc4API.Dtos;
using AnnuaireBloc4API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnnuaireBloc4API.Controllers
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
			return Ok(employeeList);
		}

		// GET api/employees/{id}
		[HttpGet("{id}", Name = "GetEmployeeById")]
		public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
		{
			var employee = _repository.GetEmployeeById(id);
			if (employee == null)
				return NotFound();
			return Ok(employee);
		}

		//POST api/employees
		[HttpPost]
		public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
		{
			// TODO check if infos are valid
			var employeeModel = _mapper.Map<Employee>(employeeCreateDto);
			_repository.CreateEmployee(employeeModel);
			try
			{
				_repository.SaveChanges();
			}
			catch (DbUpdateException e)
			{
				return BadRequest(new DbError(e.Message, e.InnerException.Message));
			}
			var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

			return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);
		}

		// PUT api/employees/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var employee = _repository.GetEmployeeByIdFull(id);
			if (employee == null)
				return NotFound();
			_mapper.Map(employeeUpdateDto, employee);
			_repository.UpdateEmployee(employee);
			try
			{
				_repository.SaveChanges();
			}
			catch (DbUpdateException e)
			{
				return BadRequest(new DbError(e.Message, e.InnerException.Message));
			}
			return NoContent();
		}

		// PATCH api/employees/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patchDocument)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var employee = _repository.GetEmployeeByIdFull(id);
			if (employee == null)
				return NotFound();
			var commandToPatch = _mapper.Map<EmployeeUpdateDto>(employee);
			patchDocument.ApplyTo(commandToPatch, ModelState);
			if (!TryValidateModel(commandToPatch))
				return ValidationProblem(ModelState);
			_mapper.Map(commandToPatch, employee);
			_repository.UpdateEmployee(employee);
			try
			{
				_repository.SaveChanges();
			}
			catch (DbUpdateException e)
			{
				return BadRequest(new DbError(e.Message, e.InnerException.Message));
			}
			return NoContent();
		}

		// DELETE api/employees/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			var employee = _repository.GetEmployeeByIdFull(id);
			if (employee == null)
				return NotFound();
			_repository.DeleteEmployee(employee);
			try
			{
				_repository.SaveChanges();
			}
			catch (DbUpdateException e)
			{
				return BadRequest(new DbError(e.Message, e.InnerException.Message));
			}
			return NoContent();
		}
	}
}