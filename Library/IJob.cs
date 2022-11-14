using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public delegate void UpdateSalary();
    public interface IJob
    {
        string JobTitle { get; set; }
        double Salary { get; set; }
        JobLocation Location { get; set; }
        Organizations Organization { get; set; }

        void CalculateSalary();
        string GetSelectedJob();

    }
}
