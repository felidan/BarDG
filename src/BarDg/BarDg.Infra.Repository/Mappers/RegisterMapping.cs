using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using System;
using System.Linq;
using System.Reflection;

namespace BarDg.Infra.Repository.Mappers
{
    public static class RegisterMapping
    {
        public static void Registrar()
        {
            FluentMapper.Initialize(config =>
            {
                var mapps = Assembly.Load("BarDg.Infra.Repository")
                                .GetTypes()
                                .Where(y => y.IsClass && typeof(IBaseMap).IsAssignableFrom(y))
                                .ToList();

                foreach (var m in mapps)
                {
                    dynamic mappClass = Activator.CreateInstance(m);
                    config.AddMap(mappClass);
                }
                config.ForDommel();
            });
        }
    }
}
