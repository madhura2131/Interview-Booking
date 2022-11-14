using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InterviewBooking
{
    class MobileRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "" || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Candidate mobile is mandatory");
            }
            else if(!long.TryParse(value.ToString(),out long tmpMobile))
            {
                return new ValidationResult(false, value.ToString());
            }
            else if(value.ToString().Length!=10)
            {
                return new ValidationResult(false, "Mobile number must be 10 digits!");
            }
            else if(value.ToString().StartsWith("0"))
            {
                return new ValidationResult(false, "Mobile number can't be started with 0");
            }

            return ValidationResult.ValidResult;
        }
    }
}
