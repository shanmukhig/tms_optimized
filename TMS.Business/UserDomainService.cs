using TMS.Business.Helpers;
using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class UserDomainService : DomainService<User>
  {
    public UserDomainService(IDataProvider<User> userDataProvider) : base(userDataProvider)
    {
    }

    public override User Create(User resource)
    {
      if (!string.IsNullOrWhiteSpace(resource.Password))
        resource.Password = resource.Password.HashPassword();
      return base.Create(resource);
    }

    //NOTE: Password can only be updated thru forgot password
  }
}