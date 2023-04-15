using AutoMapper;

namespace TaskInforce.BLL.Mapper
{
    public static class AutoMapper<TSourse, TDestination>
    {
        public static TDestination Map(TSourse sourse)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSourse, TDestination>().ReverseMap());
            var mapper = config.CreateMapper();

            return mapper.Map<TDestination>(sourse);
        }
    }
}
