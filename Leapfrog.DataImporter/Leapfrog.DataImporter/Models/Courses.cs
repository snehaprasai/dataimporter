using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Models
{
    public class Courses
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Fees { get; set; }
        public string ToCSV()
        {
            return CourseCode + "," + CourseName + "," + Fees;
        }
    }
}
