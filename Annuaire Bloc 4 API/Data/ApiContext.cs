using AnnuaireBloc4API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AnnuaireBloc4API.Data
{
	public class ApiContext : DbContext
	{
		public ApiContext(DbContextOptions<ApiContext> opt) : base(opt)
		{

		}

		public DbSet<Site> Sites { get; set; }

		public DbSet<Department> Departments { get; set; }

		public DbSet<Employee> Employees { get; set; }

	}
}