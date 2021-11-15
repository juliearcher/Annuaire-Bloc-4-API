using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using AutoMapper;

namespace Annuaire_Bloc_4_API.Profiles
{
	public class DepartmentsProfile : Profile
	{
		public DepartmentsProfile()
		{
			// Department to DepartmentReadDto
			CreateMap<Department, DepartmentReadDto>();
			// DepartmentCreateDto to Department
			CreateMap<DepartmentCreateDto, Department>();
			//For PUT and PATCH
			CreateMap<DepartmentUpdateDto, Department>();
			// For PATCH
			CreateMap<Department, DepartmentUpdateDto>();
		}
	}
}