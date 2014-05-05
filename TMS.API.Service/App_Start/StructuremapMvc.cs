using System.Web.Http;
using System.Web.Mvc;
using StructureMap;
using TMS.API.Service;
using TMS.API.Service.DependencyResolution;

[assembly: WebActivator.PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]

namespace TMS.API.Service
{
  public static class StructuremapMvc
  {
    public static void Start()
    {
      IContainer container = IoC.Initialize();
      DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
    }
  }
}