using Leapfrog.DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapfrog.DataImporter.Repository
{
    public interface IDiscountRepository
    {
        void Insert(Discount Discount);
        Discount GetByTitle(string title);
        IList<Discount> GetAll();
    }
    public class DiscountRepository : IDiscountRepository
    {
        public IList<Discount> _DiscountList = new List<Discount>();
        public IList<Discount> GetAll()
        {
            return _DiscountList;
        }

        public Discount GetByTitle(string title)
        {
            foreach(Discount d in _DiscountList)
            {
                if (d.Title == title)
                {
                    return d;
                }
            }
            return null;
        }

        public void Insert(Discount Discount)
        {
            _DiscountList.Add(Discount);
        }
    }
}
