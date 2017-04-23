using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.DataImporter.Models;
using Leapfrog.DataImporter.Repository;
using Leapfrog.DataImporter.Util;
using System.IO;

namespace Leapfrog.DataImporter.Config
{
    public class DataLoader
    {
        public IStudentRepository StudentRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IBatchRepository BatchRepository { get; set; }
        public IDiscountRepository DiscountRepository { get; set; }

        public IList<Batch> _BatchList = new List<Batch>();
        public IList<Students> _StudentList = new List<Students>();
        public IList<Courses> _CoursesList = new List<Courses>();
        public IList<Discount> _DiscountList = new List<Discount>();
        
        public void LoadData(string file, int size)
        {

            foreach (string line in Importer.ReadLines(file))
            {
                string[] tokens = line.Split(",".ToCharArray());
                if (tokens.Length > size)
                {
                    int stdId = Convert.ToInt32(tokens[0]);
                    Students student = StudentRepository.GetById(stdId);
                    if (student == null)
                    {
                        _StudentList.Add(mapStudentsData(tokens));
                        string courseCode = tokens[4];
                        Courses course = CourseRepository.GetByCode(courseCode);
                        if (course == null)
                        {
                            Console.WriteLine("Courses name of {0} is not inserted.", tokens[4]);
                            _CoursesList.Add(mapCoursesData(tokens));
                            
                            _BatchList.Add(mapBatchData(tokens));
                            string discountTitle = tokens[8];
                            Discount discount = DiscountRepository.GetByTitle(discountTitle);
                            if (discount == null)
                            {
                                Console.WriteLine("Discount Package for {0} not inserted.", tokens[8]);
                                _DiscountList.Add(mapDiscountData(tokens));
                            }
                           
                        }
                        
                    }

                }
                               
            }
            foreach (Students s in _StudentList)
            {
                Students student = StudentRepository.GetById(s.id);
                if (student == null)
                {
                    StudentRepository.Insert(s);
                }
            }
            
               
                foreach (Courses c in _CoursesList)
                {
                    
                    CourseRepository.Insert(c);
                }
            
            
            foreach (Batch b in _BatchList)
            {
                BatchRepository.Insert(b);
            }
            foreach (Discount d in _DiscountList)
            {
                DiscountRepository.Insert(d);
            }
        }
        public Students mapStudentsData(string[] tokens)
        {
            Students student = new Students();
            student.id = Convert.ToInt32(tokens[0]);
            student.fname = tokens[1];
            student.lname = tokens[2];
            student.email = tokens[3];
            student.Amount = Convert.ToInt32(tokens[7]);
            return student;
        }
        //public Courses mapCoursesData(string[] tokens)
        //{
        //    Courses course = new Courses();
        //    course.CourseCode = tokens[4];
        //    course.Fees = Convert.ToInt32(tokens[6]);
        //    return course;
        //}
        public Courses mapCoursesData(string[] tokens)
        {
            Courses course = new Courses();
            course.CourseCode = tokens[4];
            Console.WriteLine("Enter Course Name:");
            course.CourseName = Console.ReadLine();
            course.Fees = Convert.ToInt32(tokens[6]);
            return course;
        }
        public Batch mapBatchData(string[] tokens)
        {
            Batch batch = new Batch();
            batch.code = tokens[5];
            return batch;
        }
       
        //public Discount mapDiscountData(string[] tokens)
        //{
        //    Discount discount = new Discount();
        //    discount.Title = tokens[8];
        //    return discount;
        //}
        public Discount mapDiscountData(string[] tokens)
        {
            Discount discount = new Discount();
            discount.Title = tokens[8];
            Console.WriteLine("Discount Percent:");
            discount.Percent = Convert.ToInt32(Console.ReadLine());
            return discount;
        }
    }
}
