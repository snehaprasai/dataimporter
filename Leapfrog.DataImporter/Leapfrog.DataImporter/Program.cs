using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Leapfrog.DataImporter.Util;
using Leapfrog.DataImporter.Config;
using Leapfrog.DataImporter.Repository;
using Leapfrog.DataImporter.Controller;
using Leapfrog.DataImporter.Models;

namespace Leapfrog.DataImporter
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            ImporterController controller = new ImporterController();
            controller.Menu();
            Console.ReadKey();
        }
    }
}
