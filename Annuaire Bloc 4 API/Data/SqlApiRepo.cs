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

		public IEnumerable<Employee> GetAllEmployees()
		{
			return _context.Employees.ToList();
		}

		public Employee GetEmployeeById(int id)
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