using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Leapfrog.DataImporter.Util
{
    public class Importer
    {
        public static List<string> ReadLines(string fileName)
        {
            List<string> lines = new List<string>();
            using(StreamReader reader = new StreamReader(fileName))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}
