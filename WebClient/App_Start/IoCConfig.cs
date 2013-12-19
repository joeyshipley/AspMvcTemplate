using System.Web.Http;
using System.Web.Mvc;
using ThinkCraft.WebClient.Infrastructure.IoC;

namespace ThinkCraft.WebClient
{
    public static class IoCConfig
    {
        public static void RegisterContainer()
        {
            var container = IoCConfiguration.Default();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}