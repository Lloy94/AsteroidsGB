using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class HourWorker : Worker
    {
        public HourWorker(string secondName, string name, int age) : base(secondName, name, age) { }

        protected override double Value(double hourValue)
        {
            double value = hourValue * 20.8 * 8;
            return value;
        }
    }
}
