using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FreelanceWorker : Worker
    {
        public FreelanceWorker(string secondName, string name, int age,decimal salary) : base(secondName, name, age, salary) { }


        public override decimal СalculateSalary()
        {
            return (decimal)20.8 * 8 * Salary;
        }

        public override string ToString()
        {
            return $"{SecondName} {Name};{Age} ; Фрилансер; Среднемесячная заработная плата: {СalculateSalary()} (руб.); Почасовая ставка: {Salary} (руб.)";
        }
    }
}
