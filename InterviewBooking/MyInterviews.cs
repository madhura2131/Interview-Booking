using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Candidate;

namespace InterviewBooking
{
    public class MyInterviews
    {
        private string interviewDate;
        private string interviewTime;
        private string candidateName;
        private string candidateEmail;
        private long candidateMobile;
        private int candidateAge;
        private GenderType candidateGender;
        private string jobField;
        private string jobPosition;
        private Organizations jobOrganizarion;
        private JobLocation jobLocation;
        private double jobSalary;

        public string InterviewDate { get => interviewDate; set => interviewDate = value; }
        public string InterviewTime { get => interviewTime; set => interviewTime = value; }
        public string CandidateName { get => candidateName; set => candidateName = value; }
        public string CandidateEmail { get => candidateEmail; set => candidateEmail = value; }
        public long CandidateMobile { get => candidateMobile; set => candidateMobile = value; }
        public int CandidateAge { get => candidateAge; set => candidateAge = value; }
        public GenderType CandidateGender { get => candidateGender; set => candidateGender = value; }
        public string JobField { get => jobField; set => jobField = value; }
        public string JobPosition { get => jobPosition; set => jobPosition = value; }
        public Organizations JobOrganizarion { get => jobOrganizarion; set => jobOrganizarion = value; }
        public JobLocation JobLocation { get => jobLocation; set => jobLocation = value; }
        public double JobSalary { get => jobSalary; set => jobSalary = value; }
    }
}
