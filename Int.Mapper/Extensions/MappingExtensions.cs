using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mapper.Extensions
{
    public static class MappingExtensions
    {
        #region Methods

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination Map<TDestination>(this object source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return AutoMapperConfiguration.Mapper.Map<TDestination>(source);
        }

        /// <summary>
        ///  Execute a mapping from the source object to the existing destination object
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TDestination Map<TSource, TDestination>(this TSource source, TDestination destination)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (destination == null)
                throw new ArgumentNullException(nameof(destination));
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="parameters"></param>
        /// <param name="membersToExpand"></param>
        /// <returns></returns>
        public static IQueryable<TDestination> Map<TDestination>(this IQueryable<object> source, object parameters = null, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return AutoMapperConfiguration.Mapper.ProjectTo(source, parameters, membersToExpand);
        }

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="parameters"></param>
        /// <param name="membersToExpand"></param>
        /// <returns></returns>
        private static IQueryable<TDestination> Map<TDestination>(this IQueryable<object> source, IDictionary<string, object> parameters, params string[] membersToExpand)
        {
            return AutoMapperConfiguration.Mapper.ProjectTo<TDestination>(source, parameters, membersToExpand);
        }

        public static TModel EntityToViewModel<TModel>(this object entity) where TModel : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<TModel>();
        }

        public static TModel EntityToViewModel<TModel>(this IReadOnlyCollection<object> entity) where TModel : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<TModel>();
        }

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object serttt
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static IQueryable<TModel> To<TModel>(this IQueryable<object> entity) where TModel : class
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return entity.Map<TModel>();
        }

        #endregion Methods
    }
}
