using System.Linq;

namespace WebAPI.Infrastructure
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source);
    }
}