using System;
using FluentValidation;
using TMS.Validation;

namespace TMS.Validations
{
  public class BestTimeToCallValidator : StopOnFirstFailureValidator<DateTime>
  {
    public BestTimeToCallValidator()
    {
      RuleFor(call => call).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
    }
  }
}