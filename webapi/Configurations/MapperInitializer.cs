using AutoMapper;
using webapi.Models;

namespace webapi.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer() 
        {
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
