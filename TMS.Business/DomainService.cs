using System.Linq;
using TMS.Data;

namespace TMS.Business
{
  public abstract class DomainService<T> : IDomainService<T> where T : class
  {
    private readonly IDataProvider<T> _dataProvider;

    protected DomainService(IDataProvider<T> dataProvider)
    {
      _dataProvider = dataProvider;
    }

    public virtual IQueryable<T> Get()
    {
      return Get((int?)null);
    }

    public virtual IQueryable<T> Get(int? count)
    {
      return _dataProvider.Get(count);
    }

    //public virtual IQueryable<T> Search(string searchString)
    //{
    //  return _dataProvider.Search(searchString);
    //}

    public virtual IQueryable<T> Get(string Id)
    {
      return _dataProvider.Get(Id);
    }

    public virtual T Create(T resource)
    {
      return _dataProvider.Create(resource);
    }

    public virtual T Update(T resource)
    {
      return _dataProvider.Update(resource);
    }

    public virtual void Delete(string Id)
    {
      _dataProvider.Delete(Id);
    }
  }
}