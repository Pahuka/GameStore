using AutoMapper;
using Domain.Entities;
using GameStoreServices.ViewModels;

namespace GameStoreServices.Mappers;

public class AppMappingProfile : Profile
{
	public AppMappingProfile()
	{
		this.CreateMap<GameViewModel, Game>()
			.ForMember(dest => dest.Id, opt => opt
				.MapFrom(src => src.Id))
			.ForMember(dest => dest.Name, opt => opt
				.MapFrom(src => src.Name))
			.ForMember(dest => dest.DevStudio, opt => opt
				.MapFrom(src => src.DevStudio))
			.ForMember(dest => dest.Genres, opt => opt
				.MapFrom(src => src.Genres
					.Select(x=> new GenreViewModel(){Name = x.Name}).ToList())).ReverseMap();

		this.CreateMap<GenreViewModel, Genre>()
			.ForMember(dest => dest.Name, opt => opt
				.MapFrom(src => src.Name)).ReverseMap();
	}
}