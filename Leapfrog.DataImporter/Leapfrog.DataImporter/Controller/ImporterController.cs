using Leapfrog.DataImporter.Config;
using Leapfrog.DataImporter.Models;
using Leapfrog.DataImporter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Controller
{
    public class ImporterController
    {
        IStudentRepository _stdRepo = new StudentRepository();
        ICourseRepository _cRepo = new CourseRepository();
        IBatchRepository _bRepo = new BatchRepository();
        IDiscountRepository _dRepo = new DiscountRepository();
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("1.Import Data");
                Console.WriteLine("2.Students");
                Console.WriteLine("3.Courses");
                Console.WriteLine("4.Batch");
                Console.WriteLine("5.Discount");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Enter your choice:");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        DataLoader();
                        break;
                    case 2:
                        students();
                        break;
                    case 3:
                        courses();
                        break;
                    case 4:
                        batch();
                        break;
                    case 5:
                        discount();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void DataLoader()
        {
            DataLoader dl = new DataLoader();
            dl.StudentRepository = _stdRepo;
            dl.CourseRepository = _cRepo;
            dl.BatchRepository = _bRepo;
            dl.DiscountRepository = _dRepo;
            dl.LoadData(FilePathConstant.ImportFile, 8);

            foreach (Discount d in _dRepo.GetAll())
            {
                Console.WriteLine("Data Imported Successfully.");
            }


        }
        public void students()
        {
            Console.WriteLine("1.Insert Students");
            Console.WriteLine("2.View Students");
            Console.WriteLine("3.Go to Main Menu");
            Console.WriteLine("Enter an option:");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    
                    insertStudents();
                    break;
                case 2:
                    foreach (Students s in _stdRepo.GetAll())
                    {
                        Console.WriteLine(s.ToCSV());
                    }
                    break;
                case 3:
                    Menu();
                    break;
            }


        }
        public void courses()
        {
            Console.WriteLine("1.Insert Courses");
            Console.WriteLine("2.View Courses");
            Console.WriteLine("3.Go to Main Menu");
            Console.WriteLine("Enter an option:");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    insertCourse();
                    break;
                case 2:
                    foreach (Courses c in _cRepo.GetAll())
                    {
                        Console.WriteLine(c.ToCSV());
                    }
                    break;
                case 3:
                    Menu();
                    break;
            }
        }
        public void batch()
        {
            Console.WriteLine("1.Insert new Batch");
            Console.WriteLine("2.View existing Batch");
            Console.WriteLine("3.Go to Main Menu");
            Console.WriteLine("Enter an option:");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    insertBatch();
                    break;
                case 2:
                    foreach (Batch b in _bRepo.GetAll())
                    {
                        Console.WriteLine(b.ToCSV());
                    }
                    break;
                case 3:
                    Menu();
                    break;
            }
        }
        public void discount()
        {
            Console.WriteLine("1.Insert Discount Schemes");
            Console.WriteLine("2.View available Schemes");
            Console.WriteLine("3.Go to Main Menu");
            Console.WriteLine("Enter an option:");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    insertDiscount();
                    break;
                case 2:
                    foreach (Discount d in _dRepo.GetAll())
                    {
                        Console.WriteLine(d.ToCSV());
                    }
                    break;
                case 3:
                    Menu();
                    break;
            }
        }
        public void insertStudents()
        {
            Console.WriteLine("Enter id:");
            int stdId = Convert.ToInt32(Console.ReadLine());
            
            Students students = _stdRepo.GetById(stdId);
            if (students == null) {
                Students s = new Students();
                s.id = stdId;
                Console.WriteLine("Enter First Name");
                s.fname = Console.ReadLine();
                Console.WriteLine("Enter Last Name:");
                s.lname = Console.ReadLine();
                Console.WriteLine("Enter email address:");
                s.email = Console.ReadLine();
                Console.WriteLine("Enter paid amount:");
                s.Amount = Convert.ToInt32(Console.ReadLine());
                _stdRepo.Insert(s);
            }
            else
            {
                Console.WriteLine("ID already Exists. Please try with new one.");
            }
            
            
        }
        public void insertCourse()
        {
            Console.WriteLine("Enter Course Code:");
            string code = Console.ReadLine();
            Courses course = _cRepo.GetByCode(code);
            if (course == null)
            {
                Courses c = new Courses();

                c.CourseCode = code;
                Console.WriteLine("Enter Course Name:");
                c.CourseName = Console.ReadLine();
                Console.WriteLine("Enter Fees:");
                c.Fees = Convert.ToInt32(Console.ReadLine());
                _cRepo.Insert(c);
            }
            else
            {
                Console.WriteLine("This Course Code Already Exists. Please try a new one");
            }
            
        }
        public void insertBatch()
        {
            string code = Console.ReadLine();
            Batch batch = _bRepo.GetByCode(code);
            if (batch == null)
            {
                Batch b = new Batch();
                Console.WriteLine("Enter batch code:");
                b.code = code;
                Console.WriteLine("Enter batch Id:");
                b.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Id:");
                b.Students.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course Code:");
                _bRepo.Insert(b);
            }
            else
            {
                Console.WriteLine("Batch Code Already Exists. Please try a new one");
            }
            
        }
        public void insertDiscount()
        {
            Console.WriteLine("Discount Title:");
            string title= Console.ReadLine();
            Discount discount = _dRepo.GetByTitle(title);
            if (discount == null)
            {
                Discount d = new Discount();
                d.Title = title;
                Console.WriteLine("Discount Rate:");
                d.Percent = Convert.ToInt32(Console.ReadLine());
                _dRepo.Insert(d);
            }
            else
            {
                Console.WriteLine("This discount package already exixts. Please try with new one");
            }
            
        }
    }
}
