using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JanuszMarcinik.Mvc.WebUI
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(m => AddProfiles(m));
            Mapper.AssertConfigurationIsValid();
        }

        private static void AddProfiles(IMapperConfigurationExpression config)
        {
            var baseType = typeof(Profile);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .Where(p => p.FullName.StartsWith("JanuszMarcinik.Mvc.WebUI"))
                .SelectMany(s => s.GetTypes())
                .Where(t => t != baseType && baseType.IsAssignableFrom(t))
                .ToList();

            foreach (var type in types)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Log(0, System.Diagnostics.Debugger.DefaultCategory, type.FullName);
                }
                config.AddProfile(Activator.CreateInstance(type) as Profile);
            }
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression, Expression<Func<TDestination, object>> selector)
        {
            expression.ForMember(selector, options => options.Ignore());

            return expression;
        }
    }
}