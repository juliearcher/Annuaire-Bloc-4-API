using Annuaire_Bloc_4_API.Dtos;
using Annuaire_Bloc_4_API.Models;
using AutoMapper;

namespace Annuaire_Bloc_4_API.Profiles
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