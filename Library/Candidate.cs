using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Candidate
    {

        public enum GenderType
        {
            Male,
            Female,
            Other
        }

        private string name;
        private string emailAddress;
        private long mobileNumber;
        private int age;
        private GenderType gender;

        public string Name { get => name; set => name = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public long MobileNumber { get => mobileNumber; set => mobileNumber = value; }
        public int Age { get => age; set => age = value; }
        public GenderType Gender { get => gender; set => gender = value; }

        public Candidate()
        {

        }

        public Candidate(string _name,string _emailAddress, long _mobileNumber,int _age,GenderType _gender)
        {
            Name = _name;
            EmailAddress = _emailAddress;
            MobileNumber = _mobileNumber;
            Age = _age;
            Gender = _gender;
        }
    }
}
