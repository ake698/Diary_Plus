using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Diary.Extension
{
    public static class ServiceCollectionExt
    {

        public static void RegisterServices(this IServiceCollection services, List<string> assemblyNames)
        {
            assemblyNames.ForEach(s => services.RegisterService(s));
        }

        /// <summary>
        /// 获取项目中所有类，然后获取得到其实现接口
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName">指向具体实现的项目</param>
        private static void RegisterService(this IServiceCollection services, string assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            var classes = assembly.GetTypes().ToList().Where(s => !s.IsInterface && !s.Name.Contains("Base", StringComparison.OrdinalIgnoreCase));
            foreach (var c in classes)
            {
                //Console.WriteLine(c);
                var interfaces = c.GetInterfaces()
                    .ToList()
                    .Where(s => s.Name.Equals($"I{c.Name}"));

                foreach (var i in interfaces)
                {
                    // 依赖注入
                    services.AddScoped(i, c);
                }
            }
        }

        
    }
}
