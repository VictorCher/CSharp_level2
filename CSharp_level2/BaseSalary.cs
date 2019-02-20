using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    abstract class BaseSalary
    {
        protected double salary;

        protected BaseSalary()
        {
            //this.salary = rate;
        }
        public double Salary => salary;
    }
}
