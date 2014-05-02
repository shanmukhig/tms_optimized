using System.Linq;
using TMS.Data;
using TMS.Entities;

namespace TMS.Business
{
  public class CourseDomainSource : DomainService<Course>
  {
    public CourseDomainSource(IDataProvider<Course> courseDataProvider) : base(courseDataProvider)
    {
    }

    public override Course Create(Course resource)
    {
      CalculateDuration(resource);
      return base.Create(resource);
    }

    public override Course Update(Course resource)
    {
      CalculateDuration(resource);
      return base.Update(resource);
    }

    private static void CalculateDuration(Course resource)
    {
      foreach (CourseTopic courseTopic in resource.CourseTopics.Where(courseTopic => courseTopic.CourseTopics != null && courseTopic.CourseTopics.Any()))
        courseTopic.Duration = courseTopic.CourseTopics.Sum(x => x.Duration);
      resource.Duration = resource.CourseTopics.Sum(x => x.Duration);
    }
  }
}