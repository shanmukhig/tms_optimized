using StructureMap;
using TMS.Business;
using TMS.Data;
using TMS.Entities;

namespace TMS.API.Service.DependencyResolution
{
  public static class IoC
  {
    public static IContainer Initialize()
    {
      return new Container(
        expression =>
        {
          expression.For<IDomainService<Course>>().HybridHttpOrThreadLocalScoped().Use<CourseDomainSource>();
          expression.For<IDomainService<Lead>>().HybridHttpOrThreadLocalScoped().Use<LeadDomainService>();
          expression.For<IDomainService<User>>().HybridHttpOrThreadLocalScoped().Use<UserDomainService>();
          expression.For<IDomainService<Country>>().HybridHttpOrThreadLocalScoped().Use<CountryDomainService>();
          expression.For<IDomainService<Instructor>>().HybridHttpOrThreadLocalScoped().Use<InstructorDomainService>();
          expression.For<IDomainService<Activity>>().HybridHttpOrThreadLocalScoped().Use<ActivityDomainService>();
          expression.For<IDomainService<InternalUser>>().HybridHttpOrThreadLocalScoped().Use<InternalUserDomainService>();
          expression.For<IDomainService<Contact>>().HybridHttpOrThreadLocalScoped().Use<ContactDomainService>();

          expression.For<IDataProvider<Course>>().HybridHttpOrThreadLocalScoped().Use<CourseDataProvider>();
          expression.For<IDataProvider<Lead>>().HybridHttpOrThreadLocalScoped().Use<LeadDataProvider>();
          expression.For<IDataProvider<User>>().HybridHttpOrThreadLocalScoped().Use<UserDataProvider>();
          expression.For<IDataProvider<Country>>().HybridHttpOrThreadLocalScoped().Use<CountryDataProvider>();
          expression.For<IDataProvider<Instructor>>().HybridHttpOrThreadLocalScoped().Use<InstructorDataProvider>();
          expression.For<IDataProvider<Activity>>().HybridHttpOrThreadLocalScoped().Use<ActivityDataProvider>();
          expression.For<IDataProvider<InternalUser>>().HybridHttpOrThreadLocalScoped().Use<InternalUserDataProvider>();
          expression.For<IDataProvider<Contact>>().HybridHttpOrThreadLocalScoped().Use<ContactDataProvider>();

          expression.Scan(scanner =>
          {
            scanner.TheCallingAssembly();
            //scanner.WithDefaultConventions();
          });
        });
    }
  }
}