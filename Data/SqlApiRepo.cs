using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using System;
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

		#region Services

		public void CreateService(Service service)
		{
			if (service == null)
				throw new ArgumentNullException(nameof(service));
			_context.Services.Add(service);
		}

		public void DeleteService(Service service)
		{
			if (service == null)
				throw new ArgumentNullException(nameof(service));
			_context.Services.Remove(service);
		}

		public IEnumerable<Service> GetAllServices()
		{
			return _context.Services.ToList();
		}

		public Service GetServiceById(int id)
		{
			return _context.Services.FirstOrDefault(p => p.Id == id);
		}

		public void UpdateService(Service service)
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

		public void UpdateEmployee(Employee service)
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