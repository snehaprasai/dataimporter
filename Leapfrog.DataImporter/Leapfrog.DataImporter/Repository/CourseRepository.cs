using Leapfrog.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Repository
{
    public interface ICourseRepository
    {
        void Insert(Courses Courses);
        Courses GetByCode(string code);
        IList<Courses> GetAll();
    }
    public class CourseRepository : ICourseRepository
    {
        public IList<Courses> _CourseList = new List<Courses>();
        public IList<Courses> GetAll()
        {
            return _CourseList;
        }

        public Courses GetByCode(string code)
        {
            foreach(Courses c in _CourseList)
            {
                if (c.CourseCode.ToLower() == code.ToLower())
                {
                    return c;
                }
            }
            return null;
        }

        public void Insert(Courses Courses)
        {
            _CourseList.Add(Courses);
        }
    }
}
