using AnnuaireBloc4API.Data;
using AnnuaireBloc4API.Dtos;
using AnnuaireBloc4API.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AnnuaireBloc4API.Controllers
{
	[Route("api/departments")]
	[ApiController]
	public class DepartmentsController : ControllerBase
	{
		private readonly IApiRepo _repository;
		private readonly IMapper _mapper;

		public DepartmentsController(IApiRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		// GET api/departments
		[HttpGet]
		public ActionResult<IEnumerable<DepartmentReadDto>> GetAllDepartments()
		{
			var departmentList = _repository.GetAllDepartments();
			return Ok(_mapper.Map<IEnumerable<DepartmentReadDto>>(departmentList));
		}

		// GET api/departments/{id}
		[HttpGet("{id}", Name = "GetDepartmentById")]
		public ActionResult<DepartmentReadDto> GetDepartmentById(int id)
		{
			var departments = _repository.GetDepartmentById(id);
			return departments != null? Ok(_mapper.Map<DepartmentReadDto>(departments)) : NotFound();
		}

		//POST api/departments
		[HttpPost]
		public ActionResult<DepartmentReadDto> CreateDepartment(DepartmentCreateDto departmentCreateDto)
		{
			// TODO check if infos are valid
			var departmentModel = _mapper.Map<Department>(departmentCreateDto);
			_repository.CreateDepartment(departmentModel);
			try
			{
				_repository.SaveChanges();
			}
			catch(DbUpdateException e)
			{
				return BadRequest(new DbError(e.Message, e.InnerException.Message));
			}
			var departmentReadDto = _mapper.Map<DepartmentReadDto>(departmentModel);

			return CreatedAtRoute(nameof(GetDepartmentById), new { Id = departmentReadDto.Id }, departmentReadDto);
		}

		// PUT api/departments/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateDepartment(int id, DepartmentUpdateDto departmentUpdateDto)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var department = _repository.GetDepartmentById(id);
			if (department == null)
				return NotFound();
			_mapper.Map(departmentUpdateDto, department);
			_repository.UpdateDepartment(department);
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

		// PATCH api/departments/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<DepartmentUpdateDto> patchDocument)
		{
			// TODO CHECK DUPLICATA OR EXCEPTION
			var department = _repository.GetDepartmentById(id);
			if (department == null)
				return NotFound();
			var commandToPatch = _mapper.Map<DepartmentUpdateDto>(department);
			patchDocument.ApplyTo(commandToPatch, ModelState);
			if (!TryValidateModel(commandToPatch))
				return ValidationProblem(ModelState);
			_mapper.Map(commandToPatch, department);
			_repository.UpdateDepartment(department);
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

		// DELETE api/departments/{api}
		[HttpDelete("{id}")]
		public ActionResult DeleteCommand(int id)
		{
			var department = _repository.GetDepartmentById(id);
			if (department == null)
				return NotFound();
			_repository.DeleteDepartment(department);
			try
			{
				_repository.SaveChanges();
			}
			catch(DbUpdateException e)
			{
				return BadRequest(new DbError(e.Message, e.InnerException.Message));
			}
			return NoContent();
		}
	}
}