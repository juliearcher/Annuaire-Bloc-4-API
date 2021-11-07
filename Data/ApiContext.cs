using Annuaire_Bloc_4_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Annuaire_Bloc_4_API.Data
{
	public class ApiContext : DbContext
	{
		public ApiContext(DbContextOptions<ApiContext> opt) : base(opt)
		{

		}

		public DbSet<Site> Sites { get; set; }
       
    }
}