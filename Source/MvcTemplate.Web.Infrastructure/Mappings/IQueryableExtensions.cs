namespace MvcTemplate.Web.Infrastructure.Mappings
{
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public static class IQueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}
