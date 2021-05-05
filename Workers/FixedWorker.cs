using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FixedWorker : Worker
    {
        public FixedWorker(string secondName, string name, int age, decimal salary) : base(secondName, name, age,salary) { }

        public override decimal СalculateSalary()
        {
            return Salary;
        }

        public override string ToString()
        {
            return $"{SecondName} {Name};{Age}; Рабочий; Среднемесячная заработная плата (фиксированная месячная оплата): {СalculateSalary()} (руб.)";
        }
    }
}
