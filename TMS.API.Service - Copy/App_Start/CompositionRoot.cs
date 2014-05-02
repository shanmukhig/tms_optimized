using StructureMap;
using TMS.API.Service.DI;
using TMS.API.Service.DI.StructureMap;
using TMS.API.Service.DI.StructureMap.Registries;
using TMS.Business;
using TMS.Data;
using TMS.Entities;

internal class CompositionRoot
{
    public static IDependencyInjectionContainer Compose()
    {
// Create the DI container
        var container = new Container();

      container.Configure(expression =>
      {
        expression.For<DomainService<Course>>().HybridHttpOrThreadLocalScoped().Use<CourseDomainSource>();
        expression.For<DomainService<Lead>>().HybridHttpOrThreadLocalScoped().Use<LeadDomainService>();
        expression.For<DomainService<User>>().HybridHttpOrThreadLocalScoped().Use<UserDomainService>();
        expression.For<DomainService<Country>>().HybridHttpOrThreadLocalScoped().Use<CountryDomainService>();

        expression.For<DataProvider<Course>>().HybridHttpOrThreadLocalScoped().Use<CourseDataProvider>();
        expression.For<DataProvider<Lead>>().HybridHttpOrThreadLocalScoped().Use<LeadDataProvider>();
        expression.For<DataProvider<User>>().HybridHttpOrThreadLocalScoped().Use<UserDataProvider>();
        expression.For<DataProvider<Country>>().HybridHttpOrThreadLocalScoped().Use<CountryDataProvider>();
        expression.Scan(scanner =>
        {
          scanner.TheCallingAssembly();
          scanner.WithDefaultConventions();
        });
      });

// Setup configuration of DI
        container.Configure(r => r.AddRegistry<MvcSiteMapProviderRegistry>());

#if DEBUG
        container.AssertConfigurationIsValid();
#endif

// Return our DI container wrapper instance
        return new StructureMapDependencyInjectionContainer(container);
    }
}
