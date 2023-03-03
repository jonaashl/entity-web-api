using AutoMapper;
using Movie_Characters_API.Models.DTOs.MovieDTOs;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>()
                .ForMember(
                    dto => dto.Characters,
                    opt => opt.MapFrom(m => m.Characters.Select(c => c.Id))
                )
                .ForMember(
                    dto => dto.FranchiseId,
                    opt => opt.MapFrom(m => m.FranchiseId)
                );
            CreateMap<MoviePutDTO, Movie>();
            CreateMap<MoviePostDTO, Movie>();

            CreateMap<Movie, MovieSummaryDTO>();
        }
    }
}
