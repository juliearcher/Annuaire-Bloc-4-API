using AnnuaireBloc4API.Dtos;
using AnnuaireBloc4API.Models;
using AutoMapper;

namespace AnnuaireBloc4API.Profiles
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