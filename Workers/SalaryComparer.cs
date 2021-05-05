using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class SalaryComparer : IComparer<Worker>
    {
        public int Compare(Worker x, Worker y)
        {
            return x.СalculateSalary() > y.СalculateSalary() ? 1 : -1;
        }
    }
}
