using AutoMapper;
using TodoAppDAL.Models;
using TodoAppBL.Models;

namespace TodoAppBL.Models
{
    public class AutoMapperconfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TodoAppDAL.Models.Profile, ProfileBL>();
                cfg.CreateMap<Todo, TodoBL>();
                cfg.CreateMap<TodoBL, Todo>();
                cfg.CreateMap<CredentialsBL, Credential>();
                cfg.CreateMap<Credential, CredentialsBL>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
