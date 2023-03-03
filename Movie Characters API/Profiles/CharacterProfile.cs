using AutoMapper;
using Movie_Characters_API.Models;
using Movie_Characters_API.Models.DTOs.CharacterDTOs;

namespace Movie_Characters_API.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile() 
        {
            CreateMap<Character, CharacterDTO>().ReverseMap();
        }
    }
}
