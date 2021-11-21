using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using AutoMapper;

namespace Annuaire_Bloc_4_API.Profiles
{
	public class EmployeesProfile : Profile
	{
		public EmployeesProfile()
		{
			// Employee to EmployeeReadDto
			CreateMap<Employee, EmployeeReadDto>();
			// EmployeeCreateDto to Employee
			CreateMap<EmployeeCreateDto, Employee>();
			//For PUT and PATCH
			CreateMap<EmployeeUpdateDto, Employee>();
			// For PATCH
			CreateMap<Employee, EmployeeUpdateDto>();
		}
	}
}