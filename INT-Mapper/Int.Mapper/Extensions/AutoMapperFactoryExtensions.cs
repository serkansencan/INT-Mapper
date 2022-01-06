using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mapper.Extensions
{
    public static class AutoMapperFactoryExtentions
    {
        #region Methods

        /// <summary>
        /// Add auto mapper configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfigurations = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                try
                {
                    var types = assembly.GetTypes();
                    mapperConfigurations.AddRange(from type in types
                                                  where !type.IsInterface
                                                  where !type.IsAbstract
                                                  where typeof(AutoMapperProfile).IsAssignableFrom(type) ||
                                                        (typeof(AutoMapperProfile).IsGenericTypeDefinition)
                                                  select type);
                }
                catch (Exception)
                {
                }

            }

            var instances = mapperConfigurations
                .Select(startup => (AutoMapperProfile)Activator.CreateInstance(startup));

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                }
            });

            //register
            AutoMapperConfiguration.Init(config);
        }

        #endregion Methods
    }
}
