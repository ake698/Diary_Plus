using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Diary.Extensions
{
    public static class AutoMapperExt
    {
        public static void AddAutoMapperAssembly(this IServiceCollection services, string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            var classes = assembly.GetTypes().ToList().Where(s => !s.IsInterface  && s.Name.EndsWith("Profiles", StringComparison.OrdinalIgnoreCase));
            foreach (var c in classes)
            {
                services.AddAutoMapper(c);
            }
            //services.AddAutoMapper()
        }
    }
}
