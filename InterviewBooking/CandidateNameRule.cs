using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InterviewBooking
{
    class CandidateNameRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "" || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Candidate name is mandatory");
            }

            return ValidationResult.ValidResult;
        }

    }
}
