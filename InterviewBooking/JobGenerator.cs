using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBooking
{
    public class JobGenerator
    {
        private List<Job> jobList;

        public List<Job> JobList { get => jobList; set => jobList = value; }

        public JobGenerator()
        {
            JobList = new List<Job>();
            GenerateArchitectJob();
            GenerateBusinessJob();
            GenerateITJob();
        }

        void GenerateArchitectJob()
        {
            foreach (var item in Enum.GetNames(typeof(Architecture.ArchitectureJobs)))
            {
                Job j = new Architecture(item.ToString(),JobLocation.Mississauga,Organizations.Bell);
                JobList.Add(j);
            }
        }

        void GenerateBusinessJob()
        {
            foreach (var item in Enum.GetNames(typeof(Business.BusinessJobs)))
            {
                Job j = new Business(item.ToString(), JobLocation.Toronto, Organizations.GoreMutual);
                JobList.Add(j);
            }
        }

        void GenerateITJob()
        {
            foreach (var item in Enum.GetNames(typeof(InformationTechnology.InformationTechnologyJobs)))
            {
                Job j = new InformationTechnology(item.ToString(), JobLocation.Waterloo, Organizations.IBM);
                JobList.Add(j);
            }
        }
    }
}
