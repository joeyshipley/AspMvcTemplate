using System;
using System.Collections.Generic;
using StructureMap;

namespace ThinkCraft.WebClient.Infrastructure.IoC
{
    public class IoCConfiguration
    {
        public static IContainer BuildContainer()
        {
            var assembliesToScan = new List<string>
            {
                "ThinkCraft.Application",
                "ThinkCraft.Data"
            };
            var customMappings = new List<Action<ConfigurationExpression>>
            {
                // (x => x.For<AbilityToSpeak>().Use<ClassC>()) // Custom Mapping Example
            };
            configureObjectFactory(assembliesToScan, customMappings);

            return ObjectFactory.Container;
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