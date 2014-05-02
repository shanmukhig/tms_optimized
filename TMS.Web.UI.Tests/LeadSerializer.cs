using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TMS.Entities;
using TMS.Entities.Enum;

namespace TMS.Web.UI.Tests
{

  public static class securityExtentions
  {
    private const int PBKDF2IterCount = 1000; // default for Rfc2898DeriveBytes
    private const int PBKDF2SubkeyLength = 256 / 8; // 256 bits
    private const int SaltSize = 128 / 8; // 128 bits

    public static string HashPassword(this string password)
    {
      byte[] salt;
      byte[] subkey;
      using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
      {
        salt = deriveBytes.Salt;
        subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
      }

      byte[] outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
      Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
      Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
      return Convert.ToBase64String(outputBytes);
    }

    public static bool VerifyHashedPassword(this string hashedPassword, string password)
    {
      byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

      // Wrong length or version header.
      if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
        return false;

      byte[] salt = new byte[SaltSize];
      Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
      byte[] storedSubkey = new byte[PBKDF2SubkeyLength];
      Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);

      byte[] generatedSubkey;
      using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, PBKDF2IterCount))
      {
        generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
      }
      return storedSubkey.SequenceEqual(generatedSubkey);
    }
  }

  [TestClass]
  public class LeadSerializer
  {

    [TestMethod]
    public void SerializeUser()
    {
      User user = new User
      {
        UserName = "shanmukhig",
        LinkedId = "535295d3a7981501ccda7aba",
        Role = UserRole.PowerUser,
        Status = Status.Active,
        Password = "shanmukhig".HashPassword()
      };
      string serializeObject = JsonConvert.SerializeObject(user);

      InternalUser internalUser = new InternalUser
      {
        CommunicationDetails = new List<CommunicationDetail>
        {
          new CommunicationDetail
          {
            CommunicationType = CommunicationType.Email,
            IsPreferred = true,
            Uri = "shanmukhig@live.com"
          },
        },
        FirstName = "Shanmukhi",
        LastName = "Goli",
        Salutation = Salutation.Mr,
        Status = Status.Active
      };

      serializeObject = JsonConvert.SerializeObject(internalUser);

      user = new User
      {
        UserName = "shanmukhig",
        LinkedId = "535295d3a7981501ccda7aba",
        Role = UserRole.Marketing,
        Status = Status.Active,
        Password = "shanmukhig".HashPassword()
      };
      serializeObject = JsonConvert.SerializeObject(user);
    }

    [TestMethod]
    public void SerializeActivity()
    {
      ActivityEntity activity = new ActivityEntity
      {
        ActivityStatus = ActivityStatus.Created,
        ActivityType = ActivityType.Phone,
        AssignedTo = "",
        DueBy = DateTime.UtcNow,
        Notes = "Test Activity which is too long and must be truncated when displayed in the index page",
        Priority = ActivityPriority.High,
        Status = Status.Active
      };
      string serializeObject = JsonConvert.SerializeObject(activity);
    }

    [TestMethod]
    public void SerializeInstructor()
    {
      Instructor i = new Instructor
      {
        CommunicationDetails = new List<CommunicationDetail>
        {
          new CommunicationDetail
          {
            CommunicationType = CommunicationType.Email,
            IsPreferred = true,
            Uri = "shanmukhig@live.com"
          }
        },
        Courses = new List<CourseExperience>
        {
          new CourseExperience
          {
            CourseId = "535d1c54a798152bdcada276",
            RelevantExperience = 10.2f
          },
        },
        Experience = 10.4f,
        FirstName = "Shanmukh",
        LastName = "Goli",
        Salutation = Salutation.Mr,
        Status = Status.Active,
        DateofJoin = DateTime.Today,
        DateOfResignation = DateTime.Today,
        Rating = 4.3f,
        InstructorType = InstructorType.Contract,
        ReferredBy = "5330108da798151680dfc1e1",
        Country = "IN",
        Certifications = new List<Certification>
        {
          new Certification
          {
            Title = "Microsoft Certified Technology Specialist .NET framework 2.0",
            CertifiedDate = DateTime.Today,
            CertifyingCompany = "Microsoft",
            Score = 850,
            ValidThru = DateTime.Today.AddYears(2)
          },
        }
      };
      string serializeObject = JsonConvert.SerializeObject(i);
    }

    [TestMethod]
    public void SerializeCourse()
    {
      //Course course = new Course
      //{
      //  CourseTopics = new List<CourseTopic>
      //  {
          
      //  },
      //  Description = 
      //};
    }

    [TestMethod]
    public void SerializeLead()
    {
      Lead lead = new Lead
      {
        BestTimeToContact = new List<DateTime?> {DateTime.UtcNow, DateTime.UtcNow.AddDays(1)},
        City = "Hyderabad",
        ClientStatus = ClientStatus.Inactive,
        FirstName = "Goli",
        ExpectedDateOfJoin = DateTime.UtcNow,
        Description = "Description",
        DemoDateTime = DateTime.UtcNow,
        Courses = new List<CourseRequested>
        {
          new CourseRequested
          {
            AmountQuoted = 999,
            CourseId = "5347aec0a7981519889f235e",
            ServiceRequired = ServiceRequired.Consulting
          },
          new CourseRequested
          {
            AmountQuoted = 99,
            CourseId = "5347b7b2a7981519889f2360",
            ServiceRequired = ServiceRequired.Consulting
          }
        },
        CommunicationDetails = new List<CommunicationDetail>
        {
          new CommunicationDetail
          {
            CommunicationType = CommunicationType.Email,
            IsPreferred = false,
            Uri = "shanmukhig@live.com"
          },
          new CommunicationDetail
          {
            CommunicationType = CommunicationType.Skype,
            IsPreferred = true,
            Uri = "shanmukhi.goli"
          }
        },
        Country = "India",
        LastName = "Shanmukhi",
        LeadSource = LeadSource.Campaign,
        LeadType = LeadType.Individual,
        Salutation = Salutation.Mr,
        Status = Status.Active
      };

      string serializeObject = JsonConvert.SerializeObject(lead);
    }
  }
}
