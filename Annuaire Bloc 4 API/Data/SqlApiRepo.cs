using AnnuaireBloc4API.Dtos;
using AnnuaireBloc4API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnuaireBloc4API.Data
{
	public class SqlApiRepo : IApiRepo
	{
		private readonly ApiContext _context;

		public SqlApiRepo(ApiContext context)
		{
			_context = context;
		}


		#region Sites
		public void CreateSite(Site site)
		{
			if (site == null)
				throw new ArgumentNullException(nameof(site));
			_context.Sites.Add(site);
		}

		public void DeleteSite(Site site)
		{
			if (site == null)
				throw new ArgumentNullException(nameof(site));
			_context.Sites.Remove(site);
		}

		public IEnumerable<Site> GetAllSites()
		{
			//var res =  _context.Sites.Select(p => new Site { Id = p.Id, City = p.City }).ToList();
			//return res;
			//Ne pas chercher tous les employés du site
			return _context.Sites.ToList();
		}


		public Site GetSiteById(int id)
		{
			return _context.Sites.FirstOrDefault(p => p.Id == id);
		}

		public void UpdateSite(Site site)
		{
			// Nothing to do
		}
		#endregion

		#region Departments

		public void CreateDepartment(Department department)
		{
			if (department == null)
				throw new ArgumentNullException(nameof(department));
			_context.Departments.Add(department);
		}

		public void DeleteDepartment(Department department)
		{
			if (department == null)
				throw new ArgumentNullException(nameof(department));
			_context.Departments.Remove(department);
		}

		public IEnumerable<Department> GetAllDepartments()
		{
			return _context.Departments.ToList();
		}

		public Department GetDepartmentById(int id)
		{
			return _context.Departments.FirstOrDefault(p => p.Id == id);
		}

		public void UpdateDepartment(Department department)
		{
			// Nothing to do
		}

		#endregion

		#region Employees
		public void CreateEmployee(Employee employee)
		{
			if (employee == null)
				throw new ArgumentNullException(nameof(employee));
			_context.Employees.Add(employee);
		}

		public void DeleteEmployee(Employee employee)
		{
			if (employee == null)
				throw new ArgumentNullException(nameof(employee));
			_context.Employees.Remove(employee);
		}

		public IEnumerable<EmployeeReadDto> GetAllEmployees()
		{
			//return _context.Employees.ToList();
			return _context.Employees.Join(_context.Departments,
				employee => employee.DepartmentsId, department => department.Id,
				(employee, department) => new { employee, department.Name })
				.Join(_context.Sites, employee => employee.employee.SitesId, site => site.Id,
				(employee, site) => new { employee, site.City })
				.Select(r => new EmployeeReadDto {
					Id = r.employee.employee.Id,
					Department = r.employee.Name,
					Mail = r.employee.employee.Mail,
					Mobile = r.employee.employee.Mobile,
					Name = r.employee.employee.Name,
					Phone = r.employee.employee.Phone,
					Site = r.City,
					Surname = r.employee.employee.Surname,
					DepartmentsId = r.employee.employee.DepartmentsId,
					SitesId = r.employee.employee.SitesId
				}).ToList();
		}

		public EmployeeReadDto GetEmployeeById(int id)
		{
			return _context.Employees.Join(_context.Departments,
				employee => employee.DepartmentsId, department => department.Id,
				(employee, department) => new { employee, department.Name })
				.Join(_context.Sites, employee => employee.employee.SitesId, site => site.Id,
				(employee, site) => new { employee, site.City })
				.Where(r => r.employee.employee.Id == id)
				.Select(r => new EmployeeReadDto
				{
					Id = r.employee.employee.Id,
					Department = r.employee.Name,
					Mail = r.employee.employee.Mail,
					Mobile = r.employee.employee.Mobile,
					Name = r.employee.employee.Name,
					Phone = r.employee.employee.Phone,
					Site = r.City,
					Surname = r.employee.employee.Surname,
					DepartmentsId = r.employee.employee.DepartmentsId,
					SitesId = r.employee.employee.SitesId
				}).FirstOrDefault();
		}

		public Employee GetEmployeeByIdFull(int id)
		{
			return _context.Employees.FirstOrDefault(p => p.Id == id);
		}

		public void UpdateEmployee(Employee department)
		{
			// Nothing to do
		}
		#endregion

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}

		
	}
}