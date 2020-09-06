using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "d";
            Assembly assembly = Assembly.Load("Diary.BLL");
            var classes = assembly.GetTypes().ToList().Where(s => !s.IsInterface && s.Name.EndsWith("Profiles"));
            foreach (var c in classes)
            {
                Console.WriteLine(c);
                var p = c.GetInterfaces()
                    .ToList()
                    .Where(s => s.Name.Equals($"I{c.Name}"));
            
            }
        }
    }
}
