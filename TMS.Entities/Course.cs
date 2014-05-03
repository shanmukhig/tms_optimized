using System;
using System.Collections.Generic;

namespace TMS.Entities
{
  public class ActivityEntity : BaseEntity
  {
    public string AssignedTo { get; set; }
    //public DateTime? StartFrom { get; set; }
    public DateTime? DueBy { get; set; }
    public ActivityPriority Priority { get; set; }
    //public ActivityRecurrence ActivityRecurrence { get; set; }
    public string Notes { get; set; }
    public ActivityStatus ActivityStatus { get; set; }
    public ActivityType ActivityType { get; set; }
  }

  public enum ActivityStatus
  {
    Created = 1,
    Started = 2,
    Completed = 3,
    Deferred = 4,
    Cancelled = 5,
  }

  public class Contact : DemographicDetail
  {
    public string CompanyName { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Zip { get; set; }
  }

  //public enum ActivityRecurrence
  //{
  //  Once = 1,
  //  Daily = 2,
  //  WeekDays = 3,
  //  WeekEnds = 4,
  //  Weekly = 5,
  //  BiWeekly = 6,
  //  Monthly = 7,
  //  Quarterly = 8,
  //  Halfyearly = 9,
  //  Yearly = 10,
  //}

  public enum ActivityPriority
  {
    High,
    Medium,
    Normal,
    Low
  }

  public enum ActivityType
  {
    Phone = 1,
    Email = 2,
    SMS = 3,
    TrackAttendance = 4,
    ScheduleDemo = 5,
    SendBankDetails = 6,
    CollectFees = 7,
    NoteRefund = 8,
    Payment = 9,
    CreateClient = 10,
    CreateLead = 11,
    FeeReport = 12,
    BatchSechduling = 13,
    EnquiryFollowup = 14,
    EmployeeAttendance = 15,
    StudentAttendance = 16
  }

  public class Instructor : DemographicDetail
  {
    public IEnumerable<CourseExperience> Courses { get; set; }
    public float? Experience { get; set; }
    public string Description { get; set; }
    public DateTime? DateofJoin { get; set; }
    public DateTime? DateOfResignation { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public InstructorType? InstructorType { get; set; }
    public float? Rating { get; set; }
    public IEnumerable<Certification> Certifications { get; set; }
    public IEnumerable<PaymentsMade> Payments { get; set; }
  }

  public class PaymentsMade
  {
    public decimal? Amount { get; set; }
    public DateTime? MadeOn { get; set; }
    public PaymentType PaymentType { get; set; }
    public string PaymentMadeBy { get; set; }
  }

  public enum PaymentType
  {
    WireTransfer = 1,
    Cash = 2,
    Cheque = 3,
    DemandDraft = 4,
    MoneyOrder = 5,
    Forex = 6
  }


  public class CourseExperience
  {
    public string CourseId { get; set; }
    public float RelevantExperience { get; set; }
  }

  public enum InstructorType
  {
    Permanent = 1,
    Contract = 2,
    OnNeedBasis = 3,
  }

  public class Course : BaseEntity
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int? Duration { get; set; }
    public int? Price { get; set; }
    public IEnumerable<string> Instructors { get; set; }
    public IEnumerable<CourseTopic> CourseTopics { get; set; }
  }

  public class Certification
  {
    public string Title { get; set; }
    public string CertifyingCompany { get; set; }
    public int? Score { get; set; }
    //public int? MinPassingScore { get; set; }
    public DateTime? CertifiedDate { get; set; }
    public DateTime? ValidThru { get; set; }
    //public string Description { get; set; }
  }
}