using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamUtils.LeadTimeTrackingHelper.Models.Validation
{
    public class NotMatchAttribute:CompareAttribute
    {
        private readonly string _otherProperty;

        public NotMatchAttribute(string otherProperty):base(otherProperty)
        {
            _otherProperty = otherProperty;
            ErrorMessage = "{0} and {1} should not be equal";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = base.IsValid(value, validationContext);
            if (result != ValidationResult.Success)
                return ValidationResult.Success;

            return new ValidationResult(FormatErrorMessage(_otherProperty));
        }
    }
}
