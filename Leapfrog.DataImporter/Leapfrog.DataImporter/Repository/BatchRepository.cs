using Leapfrog.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Repository
{
    public interface IBatchRepository
    {
        void Insert(Batch Batch);
        Batch GetByCode(string code);
        IList<Batch> GetAll();
    }
    public class BatchRepository : IBatchRepository
    {
        public IList<Batch> _BatchList = new List<Batch>();
        public IList<Batch> GetAll()
        {
            return _BatchList;
        }

        public Batch GetByCode(string code)
        {
            foreach(Batch b in _BatchList)
            {
                if (b.code.ToLower()== code.ToLower())
                {
                    return b;
                }
            }
            return null;
        }

        public void Insert(Batch Batch)
        {
            _BatchList.Add(Batch);
        }
    }
}
