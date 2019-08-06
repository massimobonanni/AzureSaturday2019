using System.Linq;
using AutoMapper;

namespace WebAPI.Infrastructure
{
    public class AutoMapperMapper : IMapper
    {
        static AutoMapperMapper()
        {
            var config = CreateMapConfig();
            instance = new AutoMapper.Mapper(config);
        }

        private static IConfigurationProvider CreateMapConfig()
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateDtoMapping(); });

            return config;
        }

        private static readonly AutoMapper.IMapper instance;

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return instance.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return instance.Map<TSource, TDestination>(source, destination);
        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return instance.ProjectTo<TDestination>(source);
        }
    }

}
