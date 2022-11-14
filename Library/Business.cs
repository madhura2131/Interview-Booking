using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Business : Job
    {
        public enum BusinessJobs
        {
            HumanResourcesManager=25,
            Accounting=30,
            FinancialAnalyst=35,
            LoanOfficer=20
        }

        private BusinessJobs selectedJob;
        public BusinessJobs SelectedJob { get => selectedJob; set => selectedJob = value; }

        public Business()
        {

        }

        public Business(string _jobTitle, JobLocation _location, Organizations _organization):base(_jobTitle,_location,_organization)
        {
            SelectedJob = (BusinessJobs)Enum.Parse(typeof(BusinessJobs), _jobTitle);
            SalaryUpdater();
        }

        public override void CalculateSalary()
        {
            double wage = (int)Enum.Parse(typeof(BusinessJobs), SelectedJob.ToString());
            double totalSalary = wage * 2040;
            Salary = totalSalary;
        }

        public override string GetSelectedJob()
        {
            return SelectedJob.ToString();
        }
    }
}
