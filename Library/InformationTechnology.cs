using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InformationTechnology : Job
    {
        public enum InformationTechnologyJobs
        {
            ComputerProgrammer=35,
            WebDeveloper=30,
            DatabaseAdministrator=40,
        }

        private InformationTechnologyJobs selectedJob;

        public InformationTechnologyJobs SelectedJob { get => selectedJob; set => selectedJob = value; }

        public InformationTechnology()
        {

        }

        public InformationTechnology(string _jobTitle, JobLocation _location, Organizations _organization) : base(_jobTitle, _location, _organization)
        {
            SelectedJob = (InformationTechnologyJobs)Enum.Parse(typeof(InformationTechnologyJobs), _jobTitle);
            SalaryUpdater();
        }

        public override void CalculateSalary()
        {
            double wage = (int)Enum.Parse(typeof(InformationTechnologyJobs), SelectedJob.ToString());
            double totalSalary = wage * 2040;
            Salary = totalSalary;
        }

        public override string GetSelectedJob()
        {
            return SelectedJob.ToString();
        }
    }
}
