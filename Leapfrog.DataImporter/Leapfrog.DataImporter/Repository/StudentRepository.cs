using Leapfrog.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Repository
{
    public interface IStudentRepository
    {
        void Insert(Students students);
        Students GetById(int id);
        IList<Students> GetAll();

    }
    public class StudentRepository : IStudentRepository
    {
        public IList<Students> _StudentList = new List<Students>();
        public IList<Students> GetAll()
        {
            return _StudentList;
        }

        public Students GetById(int id)
        {
            foreach (Students s in _StudentList)
            {
                if (s.id == id)
                {
                    return s;
                }
            }
            return null;
        }

        public void Insert(Students students)
        {
            _StudentList.Add(students);
        }
    }
}
