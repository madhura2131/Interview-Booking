using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InterviewBooking
{
    class AgeRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "" || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Candidate age is mandatory");
            }
            else if(!int.TryParse(value.ToString(),out int tmpAge))
            {
                return new ValidationResult(false, "Age is invalid!");
            }
            else if (int.TryParse(value.ToString(), out int age))
            {
                if(age<=0)
                {
                    return new ValidationResult(false, "Age must be greater than zero");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
