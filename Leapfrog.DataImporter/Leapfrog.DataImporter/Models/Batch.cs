using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Models
{
    public class Batch
    {
        public int id { get; set; }
        public string code { get; set; }
        public Students Students { get; set; }
        public Courses Courses { get; set; }
        public string ToCSV()
        {
            return code;
        }
    }
}
