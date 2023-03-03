using AutoMapper;
using Movie_Characters_API.Models.DTOs.FranchiseDTOs;
using Movie_Characters_API.Models;

namespace Movie_Characters_API.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseDTO>()
                .ForMember(
                dto => dto.Movies,
                opt => opt.MapFrom(f => f.Movies.Select(m => m.Id).ToList()));
            CreateMap<FranchisePutDTO, Franchise>();
            CreateMap<FranchisePostDTO, Franchise>();

            CreateMap<Franchise, FranchiseSummaryDTO>();

        }
    }
}
