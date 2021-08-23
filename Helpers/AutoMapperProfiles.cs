using AutoMapper;
using WebApplication2.Dtoes;
using WebApplication2.Models;

namespace WebApplication2.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
             {
             CreateMap<Country, CountryDto>().ReverseMap();
             }
       
    }
}
