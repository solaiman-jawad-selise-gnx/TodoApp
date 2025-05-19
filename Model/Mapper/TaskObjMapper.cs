using AutoMapper;
using TodoApp.Model.DTO;

namespace TodoApp.Model.Mapper;

public class TaskObjMapper
{
    public static AutoMapper.Mapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskDTO, TodoTask>().ReverseMap();
            }
        );
       var mapper = new AutoMapper.Mapper(config);
       return mapper;
    }
}