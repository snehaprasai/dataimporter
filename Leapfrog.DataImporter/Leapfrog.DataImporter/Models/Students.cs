using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Models
{
    public class Students
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public int Amount { get; set; }
        public string ToCSV()
        {
            return id + "," + fname + "," + lname + "," + email+","+Amount ;
        }
    }
}
