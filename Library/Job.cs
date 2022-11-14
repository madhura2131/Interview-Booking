using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library
{
    public abstract class Job:IJob
    {
        private string jobTitle;
        private double salary;
        private JobLocation location;
        private Organizations organization;
        private UpdateSalary salaryUpdater;
        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public double Salary { get => salary; set => salary = value; }
        public JobLocation Location { get => location; set => location = value; }
        public Organizations Organization { get => organization; set => organization = value; }
        [XmlIgnore]
        public UpdateSalary SalaryUpdater { get => salaryUpdater; set => salaryUpdater = value; }

        public Job()
        {

        }

        public Job(string _jobTitle,JobLocation _location,Organizations _organization)
        {
            JobTitle = _jobTitle;
            Location = _location;
            Organization = _organization;
            SalaryUpdater += CalculateSalary;
        }

        public abstract void CalculateSalary();
        public abstract string GetSelectedJob();
    }
}
