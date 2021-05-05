using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
   public  abstract class Worker 
    {
        public  string Name { get; set; }
        public  string SecondName { get; set; }
        public  int Age { get; set; }
       
        public  decimal Salary { get; set; }
        
        public  abstract decimal СalculateSalary();
      
        public  Worker(string secondName, string name, int age,decimal salary)
        {
            SecondName = secondName;
            Name = name;
            Age = age;
            Salary = salary;
        }


    }
}
