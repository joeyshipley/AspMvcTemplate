using System;
using System.Collections.Generic;
using StructureMap;

namespace ThinkCraft.WebClient.Infrastructure.IoC
{
    public class IoCConfiguration
    {
        private static readonly List<string> _assembliesToScan = new List<string>
        {
            "ThinkCraft.Application",
            "ThinkCraft.Data"
        };
        private static readonly List<Action<ConfigurationExpression>> _customMappings = new List<Action<ConfigurationExpression>>
        {
            // (x => x.For<AbilityToSpeak>().Use<ClassC>()) // Custom Mapping Example
        };

        public static IContainer Default()
        {
            configureObjectFactory(_assembliesToScan, _customMappings);
            return ObjectFactory.Container;
        }

        public static IContainer BuildContainer(List<Action<ConfigurationExpression>> additionalCustomMappings)
        {
            var customMappings = new List<Action<ConfigurationExpression>>();
            customMappings.AddRange(_customMappings);
            customMappings.AddRange(additionalCustomMappings);
            return configureContainer(_assembliesToScan, customMappings);
        }

        private static IContainer configureContainer(List<string> assemblies, List<Action<ConfigurationExpression>> customMappings)
        {
            return new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.LookForRegistries();
                    assemblies.ForEach(scan.Assembly);
                    scan.WithDefaultConventions();
                });
                customMappings.ForEach(mapping => mapping(x));
            });
        }

        private static void configureObjectFactory(List<string> assemblies, List<Action<ConfigurationExpression>> customMappings)
        {
            ObjectFactory.Configure(x =>
            {
                x.Scan(scan =>
                {
                    scan.LookForRegistries();
                    assemblies.ForEach(scan.Assembly);
                    scan.WithDefaultConventions();
                });
                customMappings.ForEach(mapping => mapping(x));
            });
        }
    }
}