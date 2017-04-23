using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Percent { get; set; }
        public string ToCSV()
        {
            return Title + "," + Percent;
        }
    }
}
