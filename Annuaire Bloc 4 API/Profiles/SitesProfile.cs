using AnnuaireBloc4API.Dtos;
using AnnuaireBloc4API.Models;
using AutoMapper;

namespace AnnuaireBloc4API.Profiles
{
	public class SitesProfile : Profile
	{
		public	SitesProfile()
		{
			// Site to SiteReadDto
			CreateMap<Site, SiteReadDto>();
			// SiteCreateDto to Site
			CreateMap<SiteCreateDto, Site>();
			//For PUT and PATCH
			CreateMap<SiteUpdateDto, Site>();
			// For PATCH
			CreateMap<Site, SiteUpdateDto>();
		}
	}
}