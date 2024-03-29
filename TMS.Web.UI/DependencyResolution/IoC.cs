using StructureMap;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
          return new Container(
                  expression =>
                  {
                    expression.For(typeof(IWebService<>)).HybridHttpOrThreadLocalScoped().Use(typeof(WebService<>));
                    expression.For<IuserExtentions>().HybridHttpOrThreadLocalScoped().Use<UserExtentions>();
                  });
        }
    }
}