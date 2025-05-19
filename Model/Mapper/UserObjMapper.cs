using AutoMapper;
using TodoApp.Model.DTO;

namespace TodoApp.Model.Mapper;

public class UserObjMapper
{
    
    public static AutoMapper.Mapper InitializeAutomapper()
    
    {
        var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, TaskUser>();
            }
        );
        var mapper = new AutoMapper.Mapper(config);
        return mapper;
    }
}