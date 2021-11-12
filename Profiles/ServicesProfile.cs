using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using AutoMapper;

namespace Annuaire_Bloc_4_API.Profiles
{
	public class ServicesProfile : Profile
	{
		public ServicesProfile()
		{
			// Service to ServiceReadDto
			CreateMap<Service, ServiceReadDto>();
			// ServiceCreateDto to Service
			CreateMap<ServiceCreateDto, Service>();
			//For PUT and PATCH
			CreateMap<ServiceUpdateDto, Service>();
			// For PATCH
			CreateMap<Service, ServiceUpdateDto>();
		}
	}
}