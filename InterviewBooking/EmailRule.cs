using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InterviewBooking
{
    class EmailRule: ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "" || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Candidate email is mandatory");
            }
            else if(!IsValid(value.ToString()))
            {
                return new ValidationResult(false, "Email is invalid!");
            }
            return ValidationResult.ValidResult;
        }

        bool IsValid(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var tmp = new MailAddress(email);
                return tmp.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
