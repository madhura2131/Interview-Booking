using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBooking
{
    public class AvailableDate
    {
        private List<string> time;
        private string date;

        public List<string> Time { get => time; set => time = value; }
        public string Date { get => date; set => date = value; }

        public AvailableDate(string _date)
        {
            Time = new List<string>();
            Date = _date;
            for (int i = 1; i < 4; i++)
            {
                Time.Add(i.ToString() + ":00 PM");
            }
        }

    }
}
