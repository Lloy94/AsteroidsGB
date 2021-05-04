using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    abstract class Worker : IComparable<Worker>
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        public Worker(string secondName, string name, int age)
        {
            SecondName = secondName;
            Name = name;
            Age = age;
        }

        public int CompareTo(Worker other)
        {
            return Age - other.Age;
        }

        protected abstract double Value(double value);
    }
}
