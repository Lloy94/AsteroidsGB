using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FixedWorker : Worker
    {
        public FixedWorker(string secondName, string name, int age) : base(secondName, name, age) { }

        protected override double Value(double monthValue)
        {
            double fixedMonthValue = monthValue;
            return fixedMonthValue;

        }
    }
}
