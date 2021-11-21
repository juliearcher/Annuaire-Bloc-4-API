using AnnuaireBloc4API.Dtos;
using AnnuaireBloc4API.Models;
using AutoMapper;

namespace AnnuaireBloc4API.Profiles
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