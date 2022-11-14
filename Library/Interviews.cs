using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library
{
    [XmlRoot("InterviewList")]
    [XmlInclude(typeof(Architecture))]
    [XmlInclude(typeof(Business))]
    [XmlInclude(typeof(InformationTechnology))]
    public class Interviews
    {
        private string interviewTime;
        private string interviewDate;
        private Candidate candidate;
        private Job job;

        public string InterviewTime { get => interviewTime; set => interviewTime = value; }
        public string InterviewDate { get => interviewDate; set => interviewDate = value; }
        public Candidate Candidate { get => candidate; set => candidate = value; }
        public Job Job { get => job; set => job = value; }

        public Interviews()
        {

        }

        public Interviews(string _time,string _date,Candidate _candidate,Job _job)
        {
            InterviewTime = _time;
            InterviewDate = _date;
            Candidate = _candidate;
            Job = _job;
        }
    }
}
