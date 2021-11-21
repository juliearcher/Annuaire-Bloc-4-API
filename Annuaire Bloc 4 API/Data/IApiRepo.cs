using AnnuaireBloc4API.Models;
using System.Collections.Generic;

namespace AnnuaireBloc4API.Data
{
	public interface IApiRepo
	{
		bool SaveChanges();

		#region Sites
		IEnumerable<Site> GetAllSites();
		Site GetSiteById(int id);
		void CreateSite(Site site);
		void UpdateSite(Site site);
		void DeleteSite(Site site);
		#endregion

		#region Departments
		IEnumerable<Department> GetAllDepartments();
		Department GetDepartmentById(int id);
		void CreateDepartment(Department department);
		void UpdateDepartment(Department department);
		void DeleteDepartment(Department department);
		#endregion

		#region Employees
		IEnumerable<Employee> GetAllEmployees();
		Employee GetEmployeeById(int id);
		void CreateEmployee(Employee employee);
		void UpdateEmployee(Employee employee);
		void DeleteEmployee(Employee employee);
		#endregion
	}
}