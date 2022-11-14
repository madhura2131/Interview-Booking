using System;

namespace Library
{
    public class Architecture : Job
    {
        public enum ArchitectureJobs
        {
            Architect = 22,
            ConstructionLaborer = 30,
            Electrician = 26,
            CivilEngineer = 35
        }

        private ArchitectureJobs selectedJob;

        public ArchitectureJobs SelectedJob { get => selectedJob; set => selectedJob = value; }

        public Architecture()
        {

        }

        public Architecture(string _jobTitle, JobLocation _location, Organizations _organization) : base(_jobTitle, _location, _organization)
        {
            SelectedJob = (ArchitectureJobs)Enum.Parse(typeof(ArchitectureJobs), _jobTitle);
            SalaryUpdater();
        }

        public override void CalculateSalary()
        {
            double wage = (int)Enum.Parse(typeof(ArchitectureJobs), SelectedJob.ToString());
            double totalSalary = wage*2040;
            Salary = totalSalary;
        }

        public override string GetSelectedJob()
        {
            return SelectedJob.ToString();
        }
    }
}
